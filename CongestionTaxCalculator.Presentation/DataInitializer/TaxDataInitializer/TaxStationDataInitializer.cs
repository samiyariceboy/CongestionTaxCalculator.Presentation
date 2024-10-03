using CongestionTaxCalculator.Domain.Common.ConstStrings;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.RegionRepositories;
using CongestionTaxCalculator.Domain.FilterSpecifications.Region;

namespace CongestionTaxCalculator.Application.DataInitializer.TaxDataInitializer
{
    public class TaxStationDataInitializer(IRegionRepository regionRepository) :
        IDataInitializer, IScopedDependency
    {
        private readonly IRegionRepository _regionRepository = regionRepository;

        public int SortNumber { get; init; } = 3;

        public async Task InitializeData()
        {
            var addedStations = new List<bool>();
            var gothenburgRegion = (await _regionRepository.FirstOrDefaultAsync
                (new GetRegionByDanamicFilterSpecification(
                new Domain.DTO.Region.GetRegionByDynamicFilterDTO
                {
                    RegionName = DataDictionary.Gothenburg
                }, RegionNavigationProperties.TaxStations), CancellationToken.None));

            addedStations.Add(gothenburgRegion.AddTaxStation("Gothenburg Station1", 57.7089, 11.9746));
            addedStations.Add(gothenburgRegion.AddTaxStation("Gothenburg Station2", 59.7089, 12.9746));
            addedStations.Add(gothenburgRegion.AddTaxStation("Gothenburg Station3", 60.7089, 13.9746));
            addedStations.Add(gothenburgRegion.AddTaxStation("Gothenburg Station4", 61.7089, 14.9746));

            if (addedStations.Any(a => a == true))
            {
                await _regionRepository.UpdateAsync(gothenburgRegion, CancellationToken.None);
            }
        }
    }
}
