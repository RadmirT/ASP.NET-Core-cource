using ECommerce.ServicesLayer.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Filters
{
    public class PageEnsureProductExistsAttribute : Attribute, IPageFilter
    {
        public void OnPageHandlerSelected(
            PageHandlerSelectedContext context)
        { }

        public void OnPageHandlerExecuting(
            PageHandlerExecutingContext context)
        {
            var service = (IProductsService)context.HttpContext
                .RequestServices.GetRequiredService(typeof(IProductsService));
            var productId = (int)context.HandlerArguments["id"];
            if (!service.DoesRecipeExist(productId))
            {
                context.Result = new NotFoundResult();
            }
        }

        public void OnPageHandlerExecuted(
            PageHandlerExecutedContext context)
        { }
    }
}
