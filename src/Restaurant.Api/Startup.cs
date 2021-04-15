using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Api.Extensions;
using Restaurant.Infrastructure.Extensions;

namespace Restaurant.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithOptions();
            services.AddCorsPolicies();
            services.AddSwagger();
            services.AddContexts();
            services.AddServices();
            services.AddRepositories();
            services.AddMappings();
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            application.UseErrorHandler(environment);
            //application.UseHttpsRedirection();
            application.UseSwagger();
            application.UseRouting();
            application.UseCors();
            application.UseAuthorization();
            application.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
