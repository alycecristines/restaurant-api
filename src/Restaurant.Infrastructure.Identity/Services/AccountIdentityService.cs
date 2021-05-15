using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Interfaces;
using Restaurant.Infrastructure.Exceptions;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Infrastructure.Identity.Models;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class AccountIdentityService : IAccountDomainService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountIdentityService(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(User newUser)
        {
            var newApplicationUser = _mapper.Map<ApplicationUser>(newUser);
            var result = await _userManager.CreateAsync(newApplicationUser);

            if (!result.Succeeded)
            {
                var message = "Uma condição inesperada foi encontrada ao criar o usuário.";
                throw new InfrastructureException(message, result.Errors);
            }

            await CreateRoleAsync(RoleConstants.Employee);
            await AssignRoleAsync(newApplicationUser, RoleConstants.Employee);

            return newUser;
        }

        private async Task CreateRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var newRole = new ApplicationRole(roleName);
                await _roleManager.CreateAsync(newRole);
            }
        }

        private async Task AssignRoleAsync(ApplicationUser newUser, string roleName)
        {
            await _userManager.AddToRoleAsync(newUser, roleName);
        }

        public async Task<User> UpdateAsync(User newUser)
        {
            var currentUser = await FindAsync(newUser.Id);
            _mapper.Map(newUser, currentUser);
            await _userManager.UpdateAsync(currentUser);
            return newUser;
        }

        public async Task DeleteAsync(Guid id)
        {
            var currentUser = await FindAsync(id);
            await _userManager.DeleteAsync(currentUser);
        }

        public async Task<bool> Exists(Guid id)
        {
            return await FindAsync(id) != null;
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
            user.EmailConfirmed = true;
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

        private async Task<ApplicationUser> FindAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        private void ValidateUser(ApplicationUser user)
        {
            if (user == null)
            {
                throw new InfrastructureException("O usuário não foi encontrado.");
            }
        }
    }
}
