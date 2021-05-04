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
                .AddEntityFrameworkStores<AuthenticationDataContext>()
                .AddDefaultTokenProviders();
        }

        private static void ConfigureIdentity(IdentityOptions options)
        {
            // TODO: Check which will be password options.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        }
    }
}
