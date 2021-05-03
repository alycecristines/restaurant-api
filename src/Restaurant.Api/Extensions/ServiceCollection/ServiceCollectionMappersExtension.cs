using System;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Identity.Mappers;
using Restaurant.Infrastructure.Identity.Mappers.Base;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionMappersExtension
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserMapper, UserMapper>();
        }
    }
}
