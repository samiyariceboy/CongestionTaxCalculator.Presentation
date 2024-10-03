namespace CongestionTaxCalculator.Domain.DTO.Tax
{
    public class GetTaxRoleDTO
    {
        public string? TaxOn { get; init; }
        public List<string>? IncludingRegionNames { get; init; }
    }
    public class GetTaxRoleByDynamicFilterDTO
    {
        public Guid TaxRoleId { get; init; }
        public string? TaxOn { get; init; }
        public List<string>? IncludingRegionNames { get; init; }
    }
}
