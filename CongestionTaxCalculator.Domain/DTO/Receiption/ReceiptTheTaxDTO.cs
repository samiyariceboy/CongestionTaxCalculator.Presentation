namespace CongestionTaxCalculator.Domain.DTO.Receiption
{
    public class ReceiptTheTaxDTO
    {
        public required Guid TaxRoleId { get; init; }

        public required DateTime ArrivalDateTime { get; init; }
        public required string TaxStationName { get; init; }
        public required string LicensePlateNumber { get; init; }
    }
}
