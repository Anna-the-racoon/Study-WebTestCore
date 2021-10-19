using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebTestCore.Shared;

namespace WebTestCore.Filters
{
    public class HeaderActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("\nExecuted method header:");

            var response = context.HttpContext.Response;

            if (response.Body == null) return;

            response.Body = new GetHtmlStream(response.Body);

            Console.WriteLine("");
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("\nExecuting method header:");
            foreach (var key in context.HttpContext.Request.Headers)
            {
                Console.WriteLine($"{key.Key}: {key.Value};");
            }

            Console.WriteLine("\nExecuting method form:");
            try
            {
                foreach (var key in context.HttpContext.Request.Form)
                {
                    Console.WriteLine($"{key.Key}: {key.Value};");
                }
            }
            catch (Exception exception)
            { 
                Console.WriteLine(exception.Message); 
            }

            Console.WriteLine("");
        }
    }
}
