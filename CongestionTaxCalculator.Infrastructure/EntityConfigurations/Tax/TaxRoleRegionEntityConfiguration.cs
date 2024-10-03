using CongestionTaxCalculator.Domain.Entities.Tax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Tax
{
    public class TaxRoleRegionEntityConfiguration : IEntityTypeConfiguration<TaxRoleRegion>
    {
        public void Configure(EntityTypeBuilder<TaxRoleRegion> builder)
        {
            builder.HasOne(one => one.TaxRole)
                .WithMany(many => many.TaxRoleRegions)
                .HasForeignKey(foreignKey => foreignKey.TaxRoleId);

            builder.HasOne(one => one.Region)
                .WithMany(many => many.TaxRoleRegions)
                .HasForeignKey(foreignKey => foreignKey.RegionId);
        }
    }
}