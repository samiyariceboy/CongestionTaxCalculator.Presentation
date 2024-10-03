using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle.Criteria
{
    public class CheckLicenvePlateNumberCriteria : CriteriaSpecification<LicensePlate>
    {
        private readonly string? _licensePlateNumber;

        public CheckLicenvePlateNumberCriteria(string? licensePlateNumber)
        {
            _licensePlateNumber = licensePlateNumber;
        }
        public override Expression<Func<LicensePlate, bool>> ToExpression()
        {
            if (_licensePlateNumber == null || _licensePlateNumber.HasValue())
            {
                return current => true;
            }
            return current => current.LicensePlateNumber == _licensePlateNumber;
        }
    }
}
