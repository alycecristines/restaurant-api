using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;

namespace Restaurant.Infrastructure.Data
{
    public class ApplicationDataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Restaurant");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().OwnsOne(x => x.Address);
            modelBuilder.Entity<Company>().OwnsOne(x => x.Phone);
        }
    }
}
