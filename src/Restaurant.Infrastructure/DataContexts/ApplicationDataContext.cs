using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;
using Restaurant.Infrastructure.DataConfigurations;
using Restaurant.Infrastructure.DataConfigurations.Base;

namespace Restaurant.Infrastructure.DataContexts
{
    public class ApplicationDataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }

        private IConfiguration _configuration;

        public ApplicationDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("Application"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration<Department>(new EntityConfiguration<Department>());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new EntityConfiguration<Product>());
            modelBuilder.ApplyConfiguration<Variation>(new EntityConfiguration<Variation>());
            modelBuilder.ApplyConfiguration<Menu>(new EntityConfiguration<Menu>());
            modelBuilder.ApplyConfiguration<Order>(new EntityConfiguration<Order>());
            modelBuilder.ApplyConfiguration<OrderItem>(new OrderItemConfiguration());
        }
    }
}
