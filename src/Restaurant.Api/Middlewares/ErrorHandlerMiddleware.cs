using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant.Domain.Exceptions;
using Restaurant.Api.Wrappers;
using Restaurant.Infrastructure.Exceptions;
using Newtonsoft.Json;
using Restaurant.Api.Options;

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
            catch (DomainException exception)
            {
                var json = GetResponseJson(exception.Message);
                var statusCode = HttpStatusCode.BadRequest;
                await WriteResponse(httpContext, json, statusCode);
            }
            catch (Exception)
            {
                var json = GetResponseJson("Uma condição inesperada foi encontrada no servidor.");
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
            return JsonConvert.SerializeObject(response, JsonOptions.Create());
        }
    }
}
