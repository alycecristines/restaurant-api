using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Repositories.Base;
using Restaurant.Infrastructure.Repositories;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionRepositoriesExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
