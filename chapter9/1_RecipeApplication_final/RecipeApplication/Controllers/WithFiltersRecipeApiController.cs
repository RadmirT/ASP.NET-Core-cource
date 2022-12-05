using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    //[Route("api/recipe")]
    //[ValidateModel, HandleException, FeatureEnabled(IsEnabled = true)]
    //public class WithFiltersRecipeApiController : ControllerBase
    //{
    //    private readonly RecipeService service;
    //    public WithFiltersRecipeApiController(RecipeService service)
    //    {
    //        this.service = service;
    //    }

    //    [HttpGet("{id}"), EnsureRecipeExists, AddLastModifedHeader]
    //    public async Task<IActionResult> Get(int id)
    //    {
    //        var detail = await this.service.GetRecipeDetailAsync(id);
    //        return Ok(detail);

    //    }

    //    [HttpPost("{id}"), EnsureRecipeExists, RequireIpAddress]
    //    public async Task<IActionResult> Edit(int id, [FromBody] UpdateRecipeCommand command)
    //    {
    //        await this.service.UpdateRecipeAsync(command);
    //        return Ok();
    //    }
    //}
}
