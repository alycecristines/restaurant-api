using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionCorsExtension
    {
        public static void RegisterCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(ConfigureCorsPolicies);
        }

        private static void ConfigureCorsPolicies(CorsOptions options)
        {
            options.AddDefaultPolicy(ConfigureDefaultCorsPolicy);
        }

        private static void ConfigureDefaultCorsPolicy(CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        }
    }
}
