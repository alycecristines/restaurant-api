using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Services.Base;
using Restaurant.Infrastructure.Exceptions;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Infrastructure.Identity.Mappers.Base;
using Restaurant.Infrastructure.Identity.Models;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IUserMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(Employee employee)
        {
            var newUser = _mapper.Map(employee);
            var result = await _userManager.CreateAsync(newUser);

            if (!result.Succeeded)
            {
                var message = "Uma condição inesperada foi encontrada ao criar o usuário.";
                throw new InfrastructureException(message, result.Errors);
            }

            await CreateRoleAsync(RoleConstants.Employee);
            await AssignRoleAsync(newUser, RoleConstants.Employee);
        }

        private async Task CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName)) return;

            var newRole = new ApplicationRole(roleName);
            await _roleManager.CreateAsync(newRole);
        }

        private async Task AssignRoleAsync(ApplicationUser newUser, string roleName)
        {
            await _userManager.AddToRoleAsync(newUser, roleName);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var currentUser = await _userManager.FindByIdAsync(employee.Id.ToString());

            _mapper.Map(employee, currentUser);

            await _userManager.UpdateAsync(currentUser);
        }

        public async Task DeleteAsync(Entity entity)
        {
            var currentUser = await _userManager.FindByIdAsync(entity.Id.ToString());
            await _userManager.DeleteAsync(currentUser);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string userName)
        {
            var user = await FindAsync(userName);

            ValidateUser(user);

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task VerifyTokenAsync(string userName, string token)
        {
            var user = await FindAsync(userName);

            ValidateUser(user);

            var provider = _userManager.Options.Tokens.PasswordResetTokenProvider;
            var purpose = UserManager<ApplicationUser>.ResetPasswordTokenPurpose;
            var isValid = await _userManager.VerifyUserTokenAsync(user, provider, purpose, token);

            if (!isValid)
            {
                throw new InfrastructureException("O token não é válido.");
            }
        }

        public async Task ResetPasswordAsync(string userName, string token, string password)
        {
            var user = await FindAsync(userName);

            ValidateUser(user);

            var result = await _userManager.ResetPasswordAsync(user, token, password);

            if (!result.Succeeded)
            {
                var message = "Uma condição inesperada foi encontrada ao alterar a senha do usuário.";
                throw new InfrastructureException(message, result.Errors);
            }
        }

        private async Task<ApplicationUser> FindAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        private void ValidateUser(ApplicationUser user)
        {
            if (user != null) return;
            throw new InfrastructureException("O usuário não foi encontrado.");
        }
    }
}
