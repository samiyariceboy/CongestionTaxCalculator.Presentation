using CongestionTaxCalculator.Domain.Common.ConstStrings;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.VehicleRepositories;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle;

namespace CongestionTaxCalculator.Application.DataInitializer.VehiclesDataInitializer
{
    public class LicensePlateDataInitializer : IDataInitializer, IScopedDependency
    {
        private readonly ILicensePlateRepository _licensePlateRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public int SortNumber { get; init; } = 6;

        public LicensePlateDataInitializer(ILicensePlateRepository licensePlateRepository,
            IVehicleRepository vehicleRepository)
        {
            _licensePlateRepository = licensePlateRepository;
            _vehicleRepository = vehicleRepository;
        }
        public async Task InitializeData()
        {
            var licensePlate = await _licensePlateRepository
                .FirstOrDefaultAsync(new GetLicensePlateByDynamicFilterSpecification
            (new GetLicensePlateByDynamicFilterDTO()
            {
                    LicensePlateNumber = DataDictionary.DefaultLicensePlateNumber
                }));

            var vehicle = await _vehicleRepository.FirstOrDefaultAsync(new GetVehiclesByDynamicFilterSpecification(
            new GetVehiclesByDynamicFilterDTO
            {
                VehicleName = DataDictionary.MilitaryVehicles
            }, VehicleNavigationProperty.LicensePlate), CancellationToken.None);

            if (licensePlate == null)
            {
                var newLicensePlate = new LicensePlate(vehicle.Id, DataDictionary.DefaultVehicleOwnerName,
                    DataDictionary.DefaultVehicleOwnerNationalCode, DataDictionary.DefaultLicensePlateNumber);

                await _licensePlateRepository.AddAsync(newLicensePlate, CancellationToken.None);
            }
        }
    }
}
