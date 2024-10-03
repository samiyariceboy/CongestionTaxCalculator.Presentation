using CongestionTaxCalculator.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Vehicles
{
    public class LicensePlateEntityConfiguration : IEntityTypeConfiguration<LicensePlate>
    {
        public void Configure(EntityTypeBuilder<LicensePlate> builder)
        {
            builder.Property(prop => prop.LicensePlateNumber)
                .HasMaxLength(50);

            builder.HasOne(one => one.Vehicle)
                .WithMany(many => many.LicensePlates)
                .HasForeignKey(foreignKey => foreignKey.VehicleId);
        }
    }
}
