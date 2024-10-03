using CongestionTaxCalculator.Domain.Entities.Tax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Tax
{
    public class TaxRoleVehicleEntityConfiguration : IEntityTypeConfiguration<TaxRoleVehicle>
    {
        public void Configure(EntityTypeBuilder<TaxRoleVehicle> builder)
        {
            builder.HasOne(one => one.Vehicle)
                .WithMany(many => many.TaxRoleVehicles)
                .HasForeignKey(foreignKey => foreignKey.VehicleId);

            builder.HasOne(one => one.TaxRole)
                .WithMany(many => many.TaxRoleVehicles)
                .HasForeignKey(foreignKey => foreignKey.TaxRoleId);
        }
    }
}