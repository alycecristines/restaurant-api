using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Filters;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionControllersExtension
    {
        public static void RegisterControllers(this IServiceCollection services)
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

        private static void ConfigureJson(Microsoft.AspNetCore.Mvc.JsonOptions options)
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = Core.Options.JsonOptions.NamingPolicy;
            options.JsonSerializerOptions.IgnoreNullValues = Core.Options.JsonOptions.IgnoreNullValues;
        }
    }
}
