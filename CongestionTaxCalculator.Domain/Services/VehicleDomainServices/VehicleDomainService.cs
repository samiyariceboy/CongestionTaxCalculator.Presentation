using CongestionTaxCalculator.Domain.Common.Exceptions;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.VehicleRepositories;

namespace CongestionTaxCalculator.Domain.Services.VehicleDomainServices
{
    public class VehicleDomainService(IVehicleRepository vehicleRepository) : IVehicleDomainService, IScopedDependency
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        public async Task RegisterLicensePlate(CreateLicensePlateDTO createLicensePlateDTo, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.FirstOrDefaultAsync(new GetVehiclesByDynamicFilterSpecification(
                new GetVehiclesByDynamicFilterDTO
                {
                    VehicleId = createLicensePlateDTo.VehicleId
                }, VehicleNavigationProperty.LicensePlate), cancellationToken) ?? throw new NotFoundException();

            var licensePlate = new LicensePlate(createLicensePlateDTo.VehicleId,
                createLicensePlateDTo.VehicleOwnerName,
                createLicensePlateDTo.VehicleOwnerName,
                createLicensePlateDTo.LicensePlateNumber);

            vehicle.AddLicensePlate(licensePlate);
            await _vehicleRepository.UpdateAsync(vehicle, cancellationToken);
        }
    }
}
