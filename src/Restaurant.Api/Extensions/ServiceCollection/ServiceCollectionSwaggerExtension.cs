using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionSwaggerExtension
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(ConfigureSwagger);
        }

        private static void ConfigureSwagger(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", GetInfo());
            options.AddSecurityDefinition("Bearer", GetSecurityScheme());
            options.AddSecurityRequirement(GetSecurityRequirement());
        }

        private static OpenApiInfo GetInfo()
        {
            return new OpenApiInfo { Title = "Restaurant.Api", Version = "v1" };
        }

        private static OpenApiSecurityScheme GetSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. Example: ""Authorization: Bearer {token}""",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            };
        }

        private static OpenApiSecurityRequirement GetSecurityRequirement()
        {
            var reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme };
            var securityScheme = new OpenApiSecurityScheme { Reference = reference };
            return new OpenApiSecurityRequirement { { securityScheme, new string[] { } } };
        }
    }
}
