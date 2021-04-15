using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant.Core.Exceptions;
using Restaurant.Api.Wrappers;
using Restaurant.Core.Configurations;

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

        private string GetResponseJson(string message)
        {
            var response = new ErrorResponse(message);
            return JsonSerializer.Serialize(response, JsonConfigurations.Create());
        }
    }
}
