using System;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionMappersExtension
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
