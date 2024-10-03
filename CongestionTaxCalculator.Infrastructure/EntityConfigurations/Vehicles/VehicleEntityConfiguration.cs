using CongestionTaxCalculator.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Vehicles
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasMany(many => many.TaxRoleVehicles)
                .WithOne(one => one.Vehicle);

            builder.HasMany(many => many.LicensePlates)
             .WithOne(one => one.Vehicle);
        }
    }
}