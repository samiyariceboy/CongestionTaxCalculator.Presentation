using CongestionTaxCalculator.Domain.Common.ConstStrings;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.TaxRepositories;
using CongestionTaxCalculator.Domain.DTO.Tax;
using CongestionTaxCalculator.Domain.FilterSpecifications.Tax;

namespace CongestionTaxCalculator.Application.DataInitializer.TaxDataInitializer
{
    public class TaxRoleDataInitializer : IDataInitializer, IScopedDependency
    {
        private readonly ITaxRepository _taxRepository;

        public int SortNumber { get; init; } = 4;

        public TaxRoleDataInitializer(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }
        public async Task InitializeData()
        {
            var taxRole = await _taxRepository
                .FirstOrDefaultAsync(new GetTaxByDynamicFilterSpecification
                (new GetTaxRoleByDynamicFilterDTO 
                {
                    TaxOn = DataDictionary.CongestionTax
                }));
            if (taxRole == null)
            {
                taxRole = new Domain.Entities.Tax.TaxRole
                    (
                        DataDictionary.CongestionTax,
                        DataDictionary.CongestionTax,
                        new Domain.Entities.Tax.ValueObjects.TaxAmount(1,
                                    Domain.Entities.Tax.ValueObjects.AmountUnit.SEK),
                        new Domain.Entities.Tax.ValueObjects.TaxAmount(100,
                        Domain.Entities.Tax.ValueObjects.AmountUnit.SEK)
                    );

                await _taxRepository.AddAsync(taxRole, CancellationToken.None);
            }
        }
    }
}
