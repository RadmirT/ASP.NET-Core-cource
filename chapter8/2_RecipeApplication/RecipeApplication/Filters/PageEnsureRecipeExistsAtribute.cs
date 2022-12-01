using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RecipeApplication.Filters
{
    public class PageEnsureRecipeExistsAttribute : Attribute, IPageFilter
    {
        public void OnPageHandlerSelected(
            PageHandlerSelectedContext context)
        { }

        public void OnPageHandlerExecuting(
            PageHandlerExecutingContext context)
        {
            var service = (RecipeService)context.HttpContext
                .RequestServices.GetService(typeof(RecipeService));
            var recipeId = (int)context.HandlerArguments["id"];
            if (!service.DoesRecipeExist(recipeId))
            {
                context.Result = new NotFoundResult();
            }
        }

        public void OnPageHandlerExecuted(
            PageHandlerExecutedContext context)
        { }
    }
}
