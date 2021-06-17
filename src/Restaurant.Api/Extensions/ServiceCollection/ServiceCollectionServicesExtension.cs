using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Identity.Services;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Services;
using Restaurant.Infrastructure.Services;

namespace Restaurant.Api.Extensions.ServiceCollection
{
    public static class ServiceCollectionServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyApplicationService, CompanyApplicationService>();
            services.AddScoped<IDepartmentApplicationService, DepartmentApplicationService>();
            services.AddScoped<IEmployeeApplicationService, EmployeeApplicationService>();
            services.AddScoped<IProductApplicationService, ProductApplicationService>();
            services.AddScoped<IVariationApplicationService, VariationApplicationService>();
            services.AddScoped<IOrderApplicationService, OrderApplicationService>();
            services.AddScoped<IAccountApplicationService, AccountApplicationService>();
            services.AddScoped<IDashboardApplicationService, DashboardApplicationService>();

            services.AddScoped<ICompanyDomainService, CompanyDomainService>();
            services.AddScoped<IDepartmentDomainService, DepartmentDomainService>();
            services.AddScoped<IEmployeeDomainService, EmployeeDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IVariationDomainService, VariationDomainService>();
            services.AddScoped<IOrderDomainService, OrderDomainService>();

            services.AddScoped<IJwtTokenDomainService, JwtTokenIdentityService>();
            services.AddScoped<IAccountDomainService, AccountIdentityService>();
            services.AddScoped<IEmailDomainService, EmailInfrastructureService>();
        }
    }
}
