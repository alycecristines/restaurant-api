using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;
using Restaurant.Infrastructure.DataConfigurations.Base;

namespace Restaurant.Infrastructure.DataConfigurations
{
    public class CompanyConfiguration : EntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x => x.Phone);
        }
    }
}
