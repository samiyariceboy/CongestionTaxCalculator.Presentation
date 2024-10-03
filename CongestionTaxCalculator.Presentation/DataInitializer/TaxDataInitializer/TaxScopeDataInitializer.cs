using CongestionTaxCalculator.Domain.DTO.Tax;
using CongestionTaxCalculator.Domain.Common.ConstStrings;
using CongestionTaxCalculator.Domain.FilterSpecifications.Tax;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.TaxRepositories;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;

namespace CongestionTaxCalculator.Application.DataInitializer.TaxDataInitializer
{
    public class TaxScopeDataInitializer(ITaxRepository taxRepository) : IDataInitializer, IScopedDependency
    {
        private readonly ITaxRepository _taxRepository = taxRepository;

        public int SortNumber { get; init; } = 5;

        public async Task InitializeData()
        {
            var addedTaxScopes = new List<bool>();

            var taxRole = await _taxRepository
                .FirstOrDefaultAsync(new GetTaxByDynamicFilterSpecification
                (new GetTaxRoleByDynamicFilterDTO
                {
                    TaxOn = DataDictionary.CongestionTax
                }, TaxRoleNavigationProperty.TaxScopes));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("06:00"),
                                                   TimeSpan.Parse("06:29"), 
                                                   new Domain.Entities.Tax.ValueObjects.
                                                   TaxAmount(8, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("06:30"),
                                                  TimeSpan.Parse("06:59"),
                                                  new Domain.Entities.Tax.ValueObjects.
                                                  TaxAmount(13, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("07:00"),
                                                  TimeSpan.Parse("07:59"),
                                                  new Domain.Entities.Tax.ValueObjects.
                                                  TaxAmount(18, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("08:00"),
                                                  TimeSpan.Parse("08:29"),
                                                  new Domain.Entities.Tax.ValueObjects.
                                                  TaxAmount(13, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("08:30"),
                                                  TimeSpan.Parse("14:59"),
                                                  new Domain.Entities.Tax.ValueObjects.
                                                  TaxAmount(8, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("15:00"),
                                                  TimeSpan.Parse("15:29"),
                                                  new Domain.Entities.Tax.ValueObjects.
                                                  TaxAmount(13, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("15:30"),
                                                  TimeSpan.Parse("16:59"),
                                                  new Domain.Entities.Tax.ValueObjects.
                                                  TaxAmount(18, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("17:00"),
                                               TimeSpan.Parse("17:59"),
                                               new Domain.Entities.Tax.ValueObjects.
                                               TaxAmount(13, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("18:29"),
                                               TimeSpan.Parse("17:59"),
                                               new Domain.Entities.Tax.ValueObjects.
                                               TaxAmount(8, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));


            addedTaxScopes.Add(taxRole.AddTaxScope(TimeSpan.Parse("18:30"),
                                               TimeSpan.Parse("05:59"),
                                               new Domain.Entities.Tax.ValueObjects.
                                               TaxAmount(0, Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)));

            if (addedTaxScopes.Any(a => a == true))
            {
                await _taxRepository.UpdateAsync(taxRole);
            }

        }
    }
}
