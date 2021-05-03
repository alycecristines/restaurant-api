using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Core.Services.Base;
using Restaurant.Infrastructure.Exceptions;
using Restaurant.Infrastructure.Identity.Models;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<object> GenerateAsync(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                throw new InfrastructureException("The user was not found.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InfrastructureException("The informed user data are not valid.");
            }

            return GenerateToken(user, roles);
        }

        private UserToken GenerateToken(ApplicationUser user, IEnumerable<string> roles)
        {
            var tokenDescriptor = GenerateTokenDescriptor(user, roles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var generatedToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializedToken = tokenHandler.WriteToken(generatedToken);
            var basicUserInfo = new BasicApplicationUser(user);
            return new UserToken(basicUserInfo, serializedToken);
        }

        private SecurityTokenDescriptor GenerateTokenDescriptor(ApplicationUser user, IEnumerable<string> roles)
        {
            return new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = GenerateCredentials(),
                Subject = GenerateClaimsIdentity(user, roles)
            };
        }

        private SigningCredentials GenerateCredentials()
        {
            var key = _configuration["Token:Key"];
            var bytesKey = Encoding.UTF8.GetBytes(key);
            var symmetricKey = new SymmetricSecurityKey(bytesKey);
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            return new SigningCredentials(symmetricKey, algorithm);
        }

        private ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return new ClaimsIdentity(claims);
        }
    }
}
