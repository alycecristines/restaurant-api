using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Restaurant.Infrastructure.Exceptions;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Infrastructure.Identity.Mappers.Base;
using Restaurant.Infrastructure.Identity.Models;
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Infrastructure.Identity.DataSeeds
{
    public class AdministratorUserDataSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserMapper _mapper;

        public AdministratorUserDataSeed(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IUserMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task Seed()
        {
            var options = GetAdministratorOptions();
            var existingUser = await _userManager.FindByNameAsync(options.UserName);

            if (existingUser != null)
            {
                await UpdateUser(existingUser, options);
                return;
            }

            await CreateUser(options);
        }

        private AdministratorOptions GetAdministratorOptions()
        {
            var options = new AdministratorOptions();
            _configuration.GetSection(AdministratorOptions.SectionName).Bind(options);
            return options;
        }

        private async Task UpdateUser(ApplicationUser existingUser, AdministratorOptions options)
        {
            _mapper.Map(options, existingUser);

            await _userManager.UpdateAsync(existingUser);
            await _userManager.RemovePasswordAsync(existingUser);
            var result = await _userManager.AddPasswordAsync(existingUser, options.Password);

            if (!result.Succeeded)
            {
                var message = "Uma condição inesperada foi encontrada ao alterar a senha do usuário.";
                throw new InfrastructureException(message, result.Errors);
            }
        }

        private async Task CreateUser(AdministratorOptions options)
        {
            var roleName = RoleConstants.Administrator;
            var newUser = _mapper.Map(options);
            var tasks = new List<Task>();

            tasks.Add(_userManager.CreateAsync(newUser, options.Password));
            tasks.Add(CreateRole(roleName));

            await Task.WhenAll(tasks);
            await _userManager.AddToRoleAsync(newUser, roleName);
        }

        private async Task CreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName)) return;

            var roleManager = new ApplicationRole(roleName);
            await _roleManager.CreateAsync(roleManager);
        }
    }
}
