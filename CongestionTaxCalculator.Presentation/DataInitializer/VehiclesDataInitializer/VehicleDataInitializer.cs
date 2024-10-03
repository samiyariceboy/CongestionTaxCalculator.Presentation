using CongestionTaxCalculator.Domain.Common.ConstStrings;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DataAccess.Repositories.VehicleRepositories;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle;

namespace CongestionTaxCalculator.Application.DataInitializer.VehiclesDataInitializer
{
    public class VehicleDataInitializer : IDataInitializer, IScopedDependency
    {
        private readonly IVehicleRepository _vehicleRepository;

        public int SortNumber { get; init; } = 2;

        public VehicleDataInitializer(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task InitializeData()
        {
            if (!(await _vehicleRepository.AnyAsync(new GetVehiclesByDynamicFilterSpecification
                (new Domain.DTO.Vehicle.GetVehiclesByDynamicFilterDTO
                {
                    VehicleName = DataDictionary.EmergencyVehicles
                }), CancellationToken.None)))
            {
                var vehicle = new Vehicle(DataDictionary.EmergencyVehicles);
                await _vehicleRepository.AddAsync(vehicle, CancellationToken.None);
            }

            if (!(await _vehicleRepository.AnyAsync(new GetVehiclesByDynamicFilterSpecification
                (new Domain.DTO.Vehicle.GetVehiclesByDynamicFilterDTO
                {
                    VehicleName = DataDictionary.ForeignVehicles
                }), CancellationToken.None)))
            {
                var vehicle = new Vehicle(DataDictionary.ForeignVehicles);
                await _vehicleRepository.AddAsync(vehicle, CancellationToken.None);
            }

            if (!(await _vehicleRepository.AnyAsync(new GetVehiclesByDynamicFilterSpecification
                (new Domain.DTO.Vehicle.GetVehiclesByDynamicFilterDTO
                {
                    VehicleName = DataDictionary.MilitaryVehicles
                }), CancellationToken.None)))
            {
                var vehicle = new Vehicle(DataDictionary.MilitaryVehicles);
                await _vehicleRepository.AddAsync(vehicle, CancellationToken.None);
            }

            if (!(await _vehicleRepository.AnyAsync(new GetVehiclesByDynamicFilterSpecification
                (new Domain.DTO.Vehicle.GetVehiclesByDynamicFilterDTO
                {
                    VehicleName = DataDictionary.DiplomatVehicles
                }), CancellationToken.None)))
            {
                var vehicle = new Vehicle(DataDictionary.DiplomatVehicles);
                await _vehicleRepository.AddAsync(vehicle, CancellationToken.None);
            }

            if (!(await _vehicleRepository.AnyAsync(new GetVehiclesByDynamicFilterSpecification
                (new Domain.DTO.Vehicle.GetVehiclesByDynamicFilterDTO
                {
                    VehicleName = DataDictionary.Motorcycles
                }), CancellationToken.None)))
            {
                var vehicle = new Vehicle(DataDictionary.Motorcycles);
                await _vehicleRepository.AddAsync(vehicle, CancellationToken.None);
            }

            if (!(await _vehicleRepository.AnyAsync(new GetVehiclesByDynamicFilterSpecification
               (new Domain.DTO.Vehicle.GetVehiclesByDynamicFilterDTO
               {
                   VehicleName = DataDictionary.Busses
               }), CancellationToken.None)))
            {
                var vehicle = new Vehicle(DataDictionary.Busses);
                await _vehicleRepository.AddAsync(vehicle, CancellationToken.None);
            }

        }
    }
}
