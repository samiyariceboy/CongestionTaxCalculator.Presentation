using CongestionTaxCalculator.Domain.Common.Utilities;

namespace CongestionTaxCalculator.Domain.DTO.Region
{
    public class RegionSelectedDto
    {
        public Guid RegionId { get; set; }
        public string RegionName  { get; init; }
        public CustomDateTimeFormat CreateDate { get; init; }
    }
}
