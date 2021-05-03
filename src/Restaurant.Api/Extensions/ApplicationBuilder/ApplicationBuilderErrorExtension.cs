using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Restaurant.Infrastructure.Middlewares;

namespace Restaurant.Api.Extensions.ApplicationBuilder
{
    public static class ApplicationBuilderErrorExtension
    {
        public static void UseErrorHandler(this IApplicationBuilder application, IHostEnvironment environment)
        {
            if (environment.IsDevelopment()) application.UseDeveloperExceptionPage();
            else application.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
