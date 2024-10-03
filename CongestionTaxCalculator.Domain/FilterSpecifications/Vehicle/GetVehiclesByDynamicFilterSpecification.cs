using Ardalis.Specification;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle.Criteria;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle
{
    public class GetVehiclesByDynamicFilterSpecification : Specification<Entities.Vehicles.Vehicle>
    {
        private readonly GetVehiclesByDynamicFilterDTO _filter;

        public GetVehiclesByDynamicFilterSpecification(GetVehiclesByDynamicFilterDTO filter, params VehicleNavigationProperty[] vehicleNavigationProperties)
        {
            _filter = filter;

            Query.Where(Criteria().ToExpression());

            vehicleNavigationProperties.ToList().ForEach(AddNavigationProperty);
        }

        private void AddNavigationProperty(VehicleNavigationProperty vehicleNavigationProperty)
        {
            switch (vehicleNavigationProperty)
            {
                case VehicleNavigationProperty.LicensePlate:
                    Query.Include(inc => inc.LicensePlates);
                    break;
                case VehicleNavigationProperty.SpeceficLicensePlate:
                    Query.Include(inc => inc.LicensePlates.Where(c => c.LicensePlateNumber == _filter.LicensePlateNumber));
                    break;
                case VehicleNavigationProperty.TaxRoleVehicles:
                    Query.Include(inc => inc.TaxRoleVehicles);
                    break;
                
                default:
                    break;
            }
        }
        private CriteriaSpecification<Entities.Vehicles.Vehicle> Criteria()
        {
            return new CheckVehicleNameCriteria(_filter.VehicleName);
        }
    }

    public enum VehicleNavigationProperty
    {
        LicensePlate,
        SpeceficLicensePlate,
        TaxRoleVehicles
    }
}
