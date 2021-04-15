using System;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
