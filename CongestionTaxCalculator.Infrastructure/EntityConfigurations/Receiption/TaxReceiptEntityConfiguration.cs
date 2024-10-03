using CongestionTaxCalculator.Domain.Entities.Receiption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Receiption
{
    public class TaxReceiptEntityConfiguration : IEntityTypeConfiguration<TaxReceipt>
    {
        public void Configure(EntityTypeBuilder<TaxReceipt> builder)
        {
            builder.HasOne(one => one.LicensePlate)
                .WithMany(many => many.TaxReceipts)
                .HasForeignKey(foreignKey  => foreignKey.LicensePlateId);

            builder.HasOne(one => one.TaxStation)
              .WithMany(many => many.TaxReceipts)
              .HasForeignKey(foreignKey => foreignKey.TaxStationId);

            builder.HasOne(one => one.TaxScope)
              .WithMany(many => many.TaxReceipts)
              .HasForeignKey(foreignKey => foreignKey.TaxScopeId);
        }
    }
}