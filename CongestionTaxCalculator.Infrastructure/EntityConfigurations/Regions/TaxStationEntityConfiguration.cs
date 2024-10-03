using CongestionTaxCalculator.Domain.Entities.Regions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Regions
{
    public class TaxStationEntityConfiguration : IEntityTypeConfiguration<TaxStation>
    {
        public void Configure(EntityTypeBuilder<TaxStation> builder)
        {
            builder.Property(prop => prop.StationName)
                .HasMaxLength(200);
            
            builder.HasOne(one => one.Region)
                .WithMany(many => many.TaxStations)
                .HasForeignKey(foreignKey => foreignKey.RegionId);

            builder.HasMany(many => many.TaxReceipts)
                .WithOne(one => one.TaxStation);
        }
    }
}
