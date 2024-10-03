namespace CongestionTaxCalculator.Domain.DTO.Vehicle
{
    public class GetVehiclesDTO
    {
        public string? VehicleName { get; init; }
    }
    public class GetVehiclesByDynamicFilterDTO
    {
        public Guid? VehicleId { get; init; }
        public string? VehicleName { get; init; }
        public string? LicensePlateNumber { get; init; }
    }
}
