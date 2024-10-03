using CongestionTaxCalculator.Domain.Common.ConstStrings;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.Services.TaxDomainServices;

namespace CongestionTaxCalculator.Application.DataInitializer.RegionDataIniatializer
{
    public class RegionDataInitializer : IDataInitializer, IScopedDependency
    {
        private readonly ITaxDomainService _taxDomainService;

        public int SortNumber { get; init; } = 1;

        public RegionDataInitializer(ITaxDomainService taxDomainService)
        {
            _taxDomainService = taxDomainService;
        }
        public async Task InitializeData()
        {
            if ((await _taxDomainService.GetRegionByDynamicFilter(new Domain.DTO.Region.GetRegionByDynamicFilterDTO
            {
                RegionName = DataDictionary.Gothenburg
            }, CancellationToken.None)) == null)
            {
                await _taxDomainService.CreaateNewRegion(new Domain.DTO.Region.CreateNewRegionDTO
                {
                    RegionName = DataDictionary.Gothenburg
                }, CancellationToken.None);
            }
            return;
        }
    }
}
