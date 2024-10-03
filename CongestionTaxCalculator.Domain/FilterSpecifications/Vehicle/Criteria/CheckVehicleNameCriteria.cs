using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle.Criteria
{
    internal class CheckVehicleNameCriteria(string? vehicleName) : CriteriaSpecification<Entities.Vehicles.Vehicle>
    {
        private readonly string? _vehicleName = vehicleName;

        public override Expression<Func<Entities.Vehicles.Vehicle, bool>> ToExpression()
        {
            if (_vehicleName == null || !_vehicleName.HasValue())
            {
                return current => true;
            }

            return current => current.VehicleName == _vehicleName;
        }
    }
}
