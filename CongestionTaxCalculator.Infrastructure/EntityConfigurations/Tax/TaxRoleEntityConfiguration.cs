using CongestionTaxCalculator.Domain.Entities.Tax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Tax
{
    public class TaxRoleEntityConfiguration : IEntityTypeConfiguration<TaxRole>
    {
        public void Configure(EntityTypeBuilder<TaxRole> builder)
        {
            builder.Property(prop => prop.TaxOn)
                .HasMaxLength(100);

            builder.Property(prop => prop.TaxDescription)
                .HasMaxLength(500);

            builder.OwnsOne(ownsOne => ownsOne.MaximumAmount);
            builder.OwnsOne(ownsOne => ownsOne.MinimumAmount);

            builder.HasMany(many => many.TaxRoleRegions)
                .WithOne(one => one.TaxRole);

            builder.HasMany(many => many.TaxRoleVehicles)
                .WithOne(one => one.TaxRole);

            builder.HasMany(many => many.TaxScopes)
                .WithOne(one => one.TaxRole);
        }
    }
}
