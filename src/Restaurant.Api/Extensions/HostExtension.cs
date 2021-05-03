using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Infrastructure.DataContexts;
using Restaurant.Infrastructure.Identity.DataContexts;
using Restaurant.Infrastructure.Identity.DataSeeds;
using Restaurant.Infrastructure.Identity.Mappers.Base;
using Restaurant.Infrastructure.Identity.Models;

namespace Restaurant.Api.Extensions
{
    public static class HostExtension
    {
        public static IHost PrepareDatabases(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            MigrateDatabases(serviceProvider);
            SeedAdministratorUser(serviceProvider);

            return host;
        }

        private static void MigrateDatabases(IServiceProvider serviceProvider)
        {
            var applicationDataContext = serviceProvider.GetService<ApplicationDataContext>();
            var authenticationDataContext = serviceProvider.GetService<AuthenticationDataContext>();

            applicationDataContext.Database.Migrate();
            authenticationDataContext.Database.Migrate();
        }

        private static void SeedAdministratorUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var userMapper = serviceProvider.GetService<IUserMapper>();

            new AdministratorUserDataSeed(userManager, roleManager, userMapper, configuration).Seed().Wait();
        }
    }
}
