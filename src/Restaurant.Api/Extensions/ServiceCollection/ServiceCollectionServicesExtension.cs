using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Services;
using Restaurant.Core.Services.Base;
using Restaurant.Infrastructure.Identity.Services;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IVariationService, VariationService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
