using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebTestCore.Filters
{
    public class FormActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("\nExecuted method form:");

            var header = context.HttpContext.Request.Headers;

            foreach (var key in header)
            {
                Console.WriteLine($"{key.Key}: {key.Value};");
            }

            Console.WriteLine("");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("\nExecuting method form:");

            var header = context.HttpContext.Request.Headers;

            foreach (var key in header)
            {
                Console.WriteLine($"{key.Key}: {key.Value};");
            }

            Console.WriteLine("");
        }
    }
}
