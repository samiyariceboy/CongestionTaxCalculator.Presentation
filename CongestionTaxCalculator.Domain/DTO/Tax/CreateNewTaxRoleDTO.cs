using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects;

namespace CongestionTaxCalculator.Domain.DTO.Tax
{
    public class TaxRoleSelectedDTO
    {
        public Guid TaxRoleId { get; init; }
        public required string? TaxOn { get; init; }
        public TaxAmount? MaximumAmount { get; init; }
        public TaxAmount? MinimumAmount { get; init; }
        public string? TaxDescription { get; init; }

        public List<RegionSelectedDto?>? RegionsIncludingTheTaxRole { get; init; }
    }
    public class CreateNewTaxRoleDTO
    {
        public required string TaxOn { get; init; }
        public TaxAmount MaximumAmount { get; init; }
        public TaxAmount MinimumAmount { get; init; }
        public string TaxDescription { get; init; }

        public string FirstSupportRegisteredRegionName { get; init; }
        public string FirstSupportRegisteredVehiclName { get; init; }
    }
}
