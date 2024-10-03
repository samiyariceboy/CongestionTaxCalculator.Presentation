using CongestionTaxCalculator.Domain.Entities.Tax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Infrastructure.EntityConfigurations.Tax
{
    public class TaxScopeEntityTypeConfiguration : IEntityTypeConfiguration<TaxScope>
    {
        public void Configure(EntityTypeBuilder<TaxScope> builder)
        {
            builder.OwnsOne(ownsOne => ownsOne.TaxAmount);

            builder.HasMany(many => many.TaxReceipts)
                .WithOne(one => one.TaxScope);
        }
    }
}