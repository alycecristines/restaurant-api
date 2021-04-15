using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Configurations;
using Restaurant.Infrastructure.Filters;

namespace Restaurant.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddControllersWithOptions(this IServiceCollection services)
        {
            services.AddControllers(ConfigureController)
                .ConfigureApiBehaviorOptions(ConfigureBehavior)
                .AddJsonOptions(ConfigureJson);
        }

        private static void ConfigureController(MvcOptions options)
        {
            options.Filters.Add<ValidationFilterAttribute>();
        }

        private static void ConfigureBehavior(ApiBehaviorOptions options)
        {
            options.SuppressModelStateInvalidFilter = true;
        }

        private static void ConfigureJson(JsonOptions options)
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonConfigurations.NamingPolicy;
            options.JsonSerializerOptions.IgnoreNullValues = JsonConfigurations.IgnoreNullValues;
        }

        public static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
