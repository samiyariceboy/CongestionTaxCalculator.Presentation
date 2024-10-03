using Ardalis.Specification;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.FilterSpecifications.Region.Criteria;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Region
{
    public class GetRegionByDanamicFilterSpecification : Specification<Entities.Regions.Region>
    {
        private readonly GetRegionByDynamicFilterDTO _getRegionByDynamicFilterDTO;

        public GetRegionByDanamicFilterSpecification(GetRegionByDynamicFilterDTO getRegionByDynamicFilterDTO, params RegionNavigationProperties[] regionNavigationProperties)
        {
            _getRegionByDynamicFilterDTO = getRegionByDynamicFilterDTO;

            Query.Where(Criteria().ToExpression());

            regionNavigationProperties.ToList().ForEach(AddRegionNavigationProperties);
        }

        private void AddRegionNavigationProperties(RegionNavigationProperties regionNavigationProperties)
        {
            switch (regionNavigationProperties)
            {
                case RegionNavigationProperties.TaxStations:
                    Query.Include(inc => inc.TaxStations);
                    break;
                default:
                    break;
            }
        }

        private CriteriaSpecification<Entities.Regions.Region> Criteria()
        {
            return new CheckRegionNameCriteria(_getRegionByDynamicFilterDTO.RegionName)
                .And(new CheckRegionIdCriteria(_getRegionByDynamicFilterDTO.RegionId));
        }
    }

    public enum RegionNavigationProperties
    {
        TaxStations
    }
}
