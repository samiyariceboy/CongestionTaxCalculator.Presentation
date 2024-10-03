using CongestionTaxCalculator.Domain.Common.Utilities;

namespace CongestionTaxCalculator.Domain.DTO.Region
{
    public class GetRegionDTO
    {
        public Guid? RegionId { get; init; }
        public string? RegionName { get; init; }
        public CustomDateFormat CustomDateFormat { get; init; }
    }
    public class GetRegionByDynamicFilterDTO
    {
        public Guid RegionId { get; init; }
        public string RegionName { get; init; }
        public CustomDateFormat CustomDateFormat { get; init; }

    }
}
