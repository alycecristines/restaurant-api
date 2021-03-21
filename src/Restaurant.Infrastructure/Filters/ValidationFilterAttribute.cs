using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.Core.Wrappers;

namespace Restaurant.Infrastructure.Filters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            WriteResult(context, GetResponse(context));
        }

        private void WriteResult(ActionExecutingContext context, ApiErrorResponse response)
        {
            var result = new JsonResult(response);
            result.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = result;
        }

        private ApiErrorResponse GetResponse(ActionExecutingContext context)
        {
            var errors = new BadRequestObjectResult(context.ModelState).Value;
            var message = "One or more validation errors occurred.";
            return new ApiErrorResponse(message, errors);
        }
    }
}
