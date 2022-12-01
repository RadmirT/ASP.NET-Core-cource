using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilterPipelineExample.Filters
{
    public class OrderedResourceFilter : Attribute, IResourceFilter, IOrderedFilter
    {
        public OrderedResourceFilter(int order)
        {
            this.Order = order;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Executing OrderedResourceFilter.OnResourceExecuting Order:{Order}");
            //context.Result = new ContentResult()
            //{
            //    Content = "IResourceFilter - Short-circuiting ",
            //};
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Executing OrderedResourceFilter.OnResourceExecuted Order:{Order}");
        }

        /// <inheritdoc />
        public int Order { get; }
    }
}
