using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant.Domain.Exceptions;
using Restaurant.Api.Wrappers;
using Restaurant.Infrastructure.Exceptions;
using Newtonsoft.Json;
using Restaurant.Api.Options;
using Microsoft.Extensions.Logging;

namespace Restaurant.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
                WriteLog(LogLevel.Information, exception);
            }
            catch (DomainException exception)
            {
                var json = GetResponseJson(exception.Message);
                var statusCode = HttpStatusCode.BadRequest;
                await WriteResponse(httpContext, json, statusCode);
                WriteLog(LogLevel.Information, exception);
            }
            catch (Exception exception)
            {
                var json = GetResponseJson("Uma condição inesperada foi encontrada no servidor.");
                var statusCode = HttpStatusCode.InternalServerError;
                await WriteResponse(httpContext, json, statusCode);
                WriteLog(LogLevel.Error, exception);
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

        private void WriteLog(LogLevel logLevel, Exception exception)
        {
            _logger.Log(logLevel, exception, exception.Message);
        }
    }
}
