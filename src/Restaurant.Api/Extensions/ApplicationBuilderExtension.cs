using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Restaurant.Infrastructure.Middlewares;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Restaurant.Api.Extensions
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
            application.UseSwagger(ConfigureSwagger);
            application.UseSwaggerUI(ConfigureSwaggerUI);
        }

        private static void ConfigureSwagger(SwaggerOptions options)
        {
            // Clean up the servers in swagger.json because they get the wrong port when hosted behind reverse proxy
            options.PreSerializeFilters.Add((swagger, request) => swagger.Servers.Clear());
        }

        private static void ConfigureSwaggerUI(SwaggerUIOptions options)
        {
            var name = "Restaurant.Api v1";
            var url = "/swagger/v1/swagger.json";
            options.SwaggerEndpoint(url, name);
        }
    }
}
