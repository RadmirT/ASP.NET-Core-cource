using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Filters
{
    public class PageValidateModelAttribute : Attribute, IPageFilter
    {
        /// <inheritdoc />
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {}

        /// <inheritdoc />
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new PageResult();
            }
        }

        /// <inheritdoc />
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {}
    }
}
