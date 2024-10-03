using Ardalis.Specification;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
using CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle.Criteria;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Vehicle
{
    public class GetLicensePlateByDynamicFilterSpecification : Specification<LicensePlate>
    {
        private readonly GetLicensePlateByDynamicFilterDTO _filter;

        public GetLicensePlateByDynamicFilterSpecification(GetLicensePlateByDynamicFilterDTO filter, params LicensePlateNavigationProperty[] licensePlateNavigationProperties)
        {
            _filter = filter;
            Query.Where(Criteria().ToExpression());
            licensePlateNavigationProperties.ToList().ForEach(AddNavigationProperty);
        }

        private void AddNavigationProperty(LicensePlateNavigationProperty licensePlateNavigationProperty)
        {
            switch (licensePlateNavigationProperty)
            {
                case LicensePlateNavigationProperty.Vehicle:
                    Query.Include(inc => inc.Vehicle);
                    break;
                case LicensePlateNavigationProperty.TaxReceipts:
                    Query.Include(inc => inc.TaxReceipts)
                        .ThenInclude(inc => inc.TaxScope)
                        .Include(inc => inc.TaxReceipts)
                        .ThenInclude(inc => inc.TaxStation);
                    break;
                default:
                    break;
            }
        }

        private CriteriaSpecification<LicensePlate> Criteria()
        {
            return new CheckLicenvePlateNumberCriteria(_filter.LicensePlateNumber);
        }
    }

    public enum LicensePlateNavigationProperty
    {
        Vehicle,
        TaxReceipts
    }
}
