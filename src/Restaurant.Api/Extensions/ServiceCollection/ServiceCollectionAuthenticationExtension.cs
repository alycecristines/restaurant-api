using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionAuthenticationExtension
    {
        public static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(ConfigureAuthentication)
                .AddJwtBearer(options => ConfigureJwtBearer(options, configuration));
        }

        private static void ConfigureAuthentication(AuthenticationOptions options)
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }

        private static void ConfigureJwtBearer(JwtBearerOptions options, IConfiguration configuration)
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = GetTokenValidationParameters(configuration);
        }

        private static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            var tokenOptions = new JwtTokenOptions();
            configuration.GetSection(JwtTokenOptions.SectionName).Bind(tokenOptions);

            var bytesKey = Encoding.UTF8.GetBytes(tokenOptions.Key);
            var symmetricKey = new SymmetricSecurityKey(bytesKey);

            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricKey,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
    }
}
