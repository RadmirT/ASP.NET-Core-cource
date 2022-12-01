using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApplication.Data;
using RecipeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication
{
    public class RecipeService
    {
        readonly AppDbContext _context;
        readonly ILogger _logger;
        public RecipeService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<RecipeService>();
        }

        public async Task<List<RecipeSummaryViewModel>> GetRecipes()
        {
            return await _context.Recipes
                .Where(r => !r.IsDeleted)
                .Select(x => new RecipeSummaryViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    TimeToCook = $"{x.TimeToCook.Hours}hrs {x.TimeToCook.Minutes}mins",
                })
                .ToListAsync();
        }

        public bool DoesRecipeExist(int id)
            => this.DoesRecipeExistAsync(id).Result;


        public async Task<bool> DoesRecipeExistAsync(int id)
        {
            return await _context.Recipes
                .Where(r => !r.IsDeleted)
                .Where(r => r.RecipeId == id)
                .AnyAsync();
        }

        public RecipeDetailViewModel GetRecipeDetail(int id) 
            => this.GetRecipeDetailAsync(id).Result;


        public async Task<RecipeDetailViewModel> GetRecipeDetailAsync(int id)
        {
            return await _context.Recipes
                .Where(x => x.RecipeId == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new RecipeDetailViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    Method = x.Method,
                    LastModified = x.LastModified,
                    Ingredients = x.Ingredients
                    .Select(item => new RecipeDetailViewModel.Item
                    {
                        Name = item.Name,
                        Quantity = $"{item.Quantity} {item.Unit}"
                    })
                })
                .SingleOrDefaultAsync();
        }


        public async Task<UpdateRecipeCommand> GetRecipeForUpdate(int recipeId)
        {
            return await _context.Recipes
                .Where(x => x.RecipeId == recipeId)
                .Where(x => !x.IsDeleted)
                .Select(x => new UpdateRecipeCommand
                {
                    Name = x.Name,
                    Method = x.Method,
                    TimeToCookHrs = x.TimeToCook.Hours,
                    TimeToCookMins = x.TimeToCook.Minutes,
                    IsVegan = x.IsVegan,
                    IsVegetarian = x.IsVegetarian,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateRecipe(CreateRecipeCommand cmd)
        {
            var recipe = cmd.ToRecipe();
            _context.Add(recipe);
            recipe.LastModified = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();
            return recipe.RecipeId;
        }

        public async Task UpdateRecipeAsync(UpdateRecipeCommand cmd)
        {
            var recipe = await _context.Recipes.FindAsync(cmd.Id);
            if (recipe == null) { throw new Exception("Unable to find the recipe"); }
            if (recipe.IsDeleted) { throw new Exception("Unable to update a deleted recipe"); }

            cmd.UpdateRecipe(recipe);
            recipe.LastModified = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe is null) { throw new Exception("Unable to find recipe"); }

            recipe.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
