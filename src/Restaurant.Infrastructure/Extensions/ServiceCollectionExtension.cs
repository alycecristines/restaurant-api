using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Restaurant.Core.Interfaces;
using Restaurant.Core.Services;
using Restaurant.Infrastructure.Data;
using Restaurant.Infrastructure.Repositories;
namespace Restaurant.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            var openApiInfo = new OpenApiInfo { Title = "Restaurant.Api", Version = "v1" };
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", openApiInfo));
        }

        public static void AddContexts(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDataContext>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IVariationService, VariationService>();
            services.AddScoped<IMenuService, MenuService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(ConfigureCorsPolicies);
        }

        private static void ConfigureCorsPolicies(CorsOptions options)
        {
            options.AddDefaultPolicy(ConfigureDefaultCorsPolicy);
        }

        private static void ConfigureDefaultCorsPolicy(CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        }
    }
}
