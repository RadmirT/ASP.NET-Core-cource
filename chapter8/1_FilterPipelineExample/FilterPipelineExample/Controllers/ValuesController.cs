using System;
using FilterPipelineExample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Controllers
{
    [ApiController]
    [LogResourceFilter]
    //[OrderedResourceFilter(1)]
    //[LogResourceFilter, LogActionFilter, LogAuthorizationFilter, LogResultFilter, LogExceptionFilter, LogAlwaysRunResultFilter]
    public class ValuesController : Controller
    {
        [HttpGet("values")]
        [LogResourceFilter]
        //[OrderedResourceFilter(0)]
        public IActionResult Index()
        {
            Console.WriteLine("Executing HomeController.Index");
            return Content("Home Page");
        }

        [HttpGet("nolog")]
        public IActionResult NoLog()
        {
            Console.WriteLine("Executing HomeController.NoLog");
            return Content("NoLog Page");
        }


        [HttpGet("exception")]
        public IActionResult Exception()
        {
            Console.WriteLine("Executing HomeController.Exception");
            throw new Exception("Exception thrown!");
        }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    Console.WriteLine("Executing HomeController.OnActionExecuting");
        //    //context.Result = new ContentResult()
        //    //{
        //    //    Content = "HomeController.OnActionExecuting - Short-circuiting ",
        //    //};
        //}

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    Console.WriteLine($"Executing HomeController.OnActionExecuted: cancelled {context.Canceled}");
        //    //context.ExceptionHandled = true;
        //    //context.Result = new ContentResult()
        //    //{
        //    //    Content = "HomeController - convert to success ",
        //    //};
        //}
    }
}
