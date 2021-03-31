using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Restaurant.Application.Configurations;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services;
using Restaurant.Application.Validators;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastructure.Data;
using Restaurant.Infrastructure.Filters;
using Restaurant.Infrastructure.Repositories;
namespace Restaurant.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddControllersWithOptions(this IServiceCollection services)
        {
            services.AddControllers(ConfigureController)
                .ConfigureApiBehaviorOptions(ConfigureBehavior)
                .AddJsonOptions(ConfigureJson);
        }

        private static void ConfigureController(MvcOptions options)
        {
            options.Filters.Add<ValidationFilterAttribute>();
        }

        private static void ConfigureBehavior(ApiBehaviorOptions options)
        {
            options.SuppressModelStateInvalidFilter = true;
        }

        private static void ConfigureJson(JsonOptions options)
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonConfigurations.NamingPolicy;
            options.JsonSerializerOptions.IgnoreNullValues = JsonConfigurations.IgnoreNullValues;
        }

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
            services.AddScoped<IServiceValidator, ServiceValidator>();
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

        public static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
