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
        private readonly AdministratorOptions _options;
        private readonly IUserMapper _mapper;

        public AdministratorUserDataSeed(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IUserMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;

            _options = new AdministratorOptions();
            configuration.GetSection(AdministratorOptions.SectionName).Bind(_options);
        }

        public async Task Seed()
        {
            var existingUser = await _userManager.FindByNameAsync(_options.UserName);

            if (existingUser != null)
            {
                await UpdateUser(existingUser);
                return;
            }

            var createdUser = await CreateUser();
            await CreateRole(RoleConstants.Administrator);
            await _userManager.AddToRoleAsync(createdUser, RoleConstants.Administrator);
        }

        private async Task UpdateUser(ApplicationUser existingUser)
        {
            _mapper.Map(_options, existingUser);
            await _userManager.UpdateAsync(existingUser);
        }

        private async Task<ApplicationUser> CreateUser()
        {
            var newUser = _mapper.Map(_options);
            var result = await _userManager.CreateAsync(newUser, _options.InitialPassword);

            if (!result.Succeeded)
            {
                var message = "Uma condição inesperada foi encontrada ao criar o usuário.";
                throw new InfrastructureException(message, result.Errors);
            }

            return newUser;
        }

        private async Task CreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName)) return;

            var roleManager = new ApplicationRole(roleName);
            await _roleManager.CreateAsync(roleManager);
        }
    }
}
