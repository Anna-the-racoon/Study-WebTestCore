using Microsoft.AspNetCore.Mvc.Filters;
using WebTestCore.Shared;

namespace WebTestCore.Filters
{
    public class BodyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;
            if (response.Body == null) return;
            response.Body = new GetHtmlStream(response.Body);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
