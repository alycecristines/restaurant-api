using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Restaurant.Infrastructure.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Restaurant.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseErrorHandler(this IApplicationBuilder application, IHostEnvironment environment)
        {
            if (environment.IsDevelopment()) application.UseDeveloperExceptionPage();
            else application.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void UseSwagger(this IApplicationBuilder application)
        {
            SwaggerBuilderExtensions.UseSwagger(application);
            application.UseSwaggerUI(ConfigureSwaggerUI);
        }

        private static void ConfigureSwaggerUI(SwaggerUIOptions options)
        {
            var name = "Restaurant.Api v1";
            var url = "/swagger/v1/swagger.json";
            options.SwaggerEndpoint(url, name);
        }
    }
}