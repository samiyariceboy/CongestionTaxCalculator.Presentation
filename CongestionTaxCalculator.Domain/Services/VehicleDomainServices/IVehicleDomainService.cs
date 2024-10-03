using CongestionTaxCalculator.Domain.DTO.Vehicle;

namespace CongestionTaxCalculator.Domain.Services.VehicleDomainServices
{
    public interface IVehicleDomainService
    {
        Task RegisterLicensePlate(CreateLicensePlateDTO createLicensePlateDTo, CancellationToken cancellationToken);
    }
}