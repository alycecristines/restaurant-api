using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Identity.DataContexts;
using Restaurant.Infrastructure.Identity.Localization;
using Restaurant.Infrastructure.Identity.Models;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionIdentityExtension
    {
        public static void RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(ConfigureIdentity)
                .AddErrorDescriber<PortugueseIdentityErrorDescriber>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();
        }

        private static void ConfigureIdentity(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
        }
    }
}
