using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Entities.Regions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Regions
{
    public class RegionEntityConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasMany(many => many.TaxRoleRegions)
                .WithOne(one => one.Region);

            builder.HasMany(many => many.TaxStations)
                .WithOne(one => one.Region);
        }
    }
}
