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
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtTokenOptions _options;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _options = new JwtTokenOptions();
            configuration.GetSection(JwtTokenOptions.SectionName).Bind(_options);
        }

        public async Task<object> GenerateAsync(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                throw new InfrastructureException("O usuário não foi encontrado.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InfrastructureException("Os dados do usuário não correspondem.");
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
                Expires = DateTime.UtcNow.AddHours(_options.Duration),
                SigningCredentials = GenerateCredentials(),
                Subject = GenerateClaimsIdentity(user, roles)
            };
        }

        private SigningCredentials GenerateCredentials()
        {
            var bytesKey = Encoding.UTF8.GetBytes(_options.Key);
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
