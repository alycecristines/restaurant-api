using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Api.Extensions.ApplicationBuilder;
using Restaurant.Api.Extensions.ServiceCollection;

namespace Restaurant.Api
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterIdentity();
            services.RegisterAuthentication(_configuration);
            services.RegisterControllers();
            services.RegisterCorsPolicies();
            services.RegisterSwagger();
            services.RegisterContexts();
            services.RegisterServices();
            services.RegisterRepositories();
            services.RegisterMappers();
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            application.UseErrorHandler(environment);
            application.UseSwagger();
            application.UseRouting();
            application.UseCors();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
