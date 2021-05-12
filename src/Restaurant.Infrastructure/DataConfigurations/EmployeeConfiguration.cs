using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.DataConfigurations.Base;

namespace Restaurant.Infrastructure.DataConfigurations
{
    public class EmployeeConfiguration : EntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
