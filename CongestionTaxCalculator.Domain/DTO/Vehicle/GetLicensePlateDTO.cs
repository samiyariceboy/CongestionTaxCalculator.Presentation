namespace CongestionTaxCalculator.Domain.DTO.Vehicle
{
    public class GetLicensePlateDTO
    {
        public string? LicensePlateNumber { get; init; }
    }

    public class GetLicensePlateByDynamicFilterDTO
    {
        public Guid LicensePlateId { get; init; }
        public string? LicensePlateNumber { get; init; }
    }
}
