using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.DataContexts;
using Restaurant.Infrastructure.Identity.DataContexts;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionContextsExtension
    {
        public static void RegisterContexts(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDataContext>();
            services.AddDbContext<AuthenticationDataContext>();
        }
    }
}
