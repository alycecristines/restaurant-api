using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant.Core.Exceptions;
using Restaurant.Api.Wrappers;
using Restaurant.Core.Options;
using Restaurant.Infrastructure.Exceptions;

namespace Restaurant.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (InfrastructureException exception)
            {
                var json = GetResponseJson(exception.Message, exception.Errors);
                var statusCode = HttpStatusCode.BadRequest;
                await WriteResponse(httpContext, json, statusCode);
            }
            catch (CoreException exception)
            {
                var json = GetResponseJson(exception.Message);
                var statusCode = HttpStatusCode.BadRequest;
                await WriteResponse(httpContext, json, statusCode);
            }
            catch (Exception)
            {
                var json = GetResponseJson("An unexpected condition was encountered on the server.");
                var statusCode = HttpStatusCode.InternalServerError;
                await WriteResponse(httpContext, json, statusCode);
            }
        }

        private async Task WriteResponse(HttpContext httpContext, string json, HttpStatusCode statusCode)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;
            await response.WriteAsync(json);
        }

        private string GetResponseJson(string message, object errors = null)
        {
            var response = new ErrorResponse(message, errors);
            return JsonSerializer.Serialize(response, JsonOptions.Create());
        }
    }
}
