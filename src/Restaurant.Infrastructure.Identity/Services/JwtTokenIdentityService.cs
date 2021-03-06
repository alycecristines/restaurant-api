using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.ValueObjects;
using Restaurant.Infrastructure.Exceptions;
using Restaurant.Infrastructure.Identity.Models;
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class JwtTokenIdentityService : IJwtTokenDomainService
    {
        private readonly JwtTokenOptions _options;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public JwtTokenIdentityService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;

            _options = new JwtTokenOptions();
            configuration.GetSection(JwtTokenOptions.SectionName).Bind(_options);
        }

        public async Task<UserToken> GenerateAsync(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                throw new InfrastructureException("O usuário não foi encontrado.");
            }

            if (!user.EmailConfirmed)
            {
                throw new InfrastructureException("O e-mail de usuário ainda não foi confirmado.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InfrastructureException("Os dados do usuário não correspondem.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            return GenerateToken(user, roles);
        }

        private UserToken GenerateToken(ApplicationUser user, IEnumerable<string> roles)
        {
            var tokenDescriptor = GenerateTokenDescriptor(user, roles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var generatedToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializedToken = tokenHandler.WriteToken(generatedToken);
            var basicUserInfo = _mapper.Map<User>(user);
            var userToken = _mapper.Map<UserToken>(basicUserInfo);
            return _mapper.Map(serializedToken, userToken);
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
