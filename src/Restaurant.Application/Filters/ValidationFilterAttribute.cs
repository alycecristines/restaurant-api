using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.Application.Wrappers;

namespace Restaurant.Application.Filters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            context.Result = GetResponse(context);
        }

        private ActionResult GetResponse(ActionExecutingContext context)
        {
            var message = "One or more validation errors occurred.";
            var errors = new BadRequestObjectResult(context.ModelState).Value;
            var response = new ApiErrorResponse(message, errors);
            return new BadRequestObjectResult(response);
        }
    }
}
