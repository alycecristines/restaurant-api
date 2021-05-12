using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Filters;
using static Restaurant.Api.Options.JsonOptions;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionControllersExtension
    {
        public static void RegisterControllers(this IServiceCollection services)
        {
            services.AddControllers(ConfigureController)
                .ConfigureApiBehaviorOptions(ConfigureBehavior)
                .AddNewtonsoftJson(ConfigureJson);
        }

        private static void ConfigureController(MvcOptions options)
        {
            options.Filters.Add<ValidationFilterAttribute>();
        }

        private static void ConfigureBehavior(ApiBehaviorOptions options)
        {
            options.SuppressModelStateInvalidFilter = true;
        }

        private static void ConfigureJson(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.ContractResolver = ContractResolver;
            options.SerializerSettings.NullValueHandling = NullValueHandling;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling;
        }
    }
}
