using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Restaurant.Core.Interfaces;
using Restaurant.Application.Services;
using Restaurant.Infrastructure.Data;
using Restaurant.Infrastructure.Repositories;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Filters;
using Restaurant.Application.Middlewares;
using Restaurant.Application.Options;

namespace Restaurant.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilterAttribute>();
            }
            ).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }
            ).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonOptions.NamingPolicy;
                options.JsonSerializerOptions.IgnoreNullValues = JsonOptions.IgnoreNullValues;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant.Api", Version = "v1" });
            });

            services.AddDbContext<ApplicationDataContext>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ErrorHandlerMiddleware>();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
