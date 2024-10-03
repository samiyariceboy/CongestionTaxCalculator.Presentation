
namespace CongestionTaxCalculator.Domain.DTO.Vehicle
{
    public class LicensePlateDTOSelectedDTO
    {
        public required string VehicleOwnerName { get; init; }
        public required string VehicleNationalCode { get; init; }
        public required string LicensePlateNumber { get; init; }
    }
    public class CreateLicensePlateDTO
    {
        public required string VehicleOwnerName { get; init; }
        public required string VehicleNationalCode { get; init; }
        public required string LicensePlateNumber { get; init; }
        public required Guid VehicleId { get; init; }
    }
}
