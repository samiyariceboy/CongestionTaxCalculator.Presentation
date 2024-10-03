using Ardalis.Specification;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.DTO.Tax;
using CongestionTaxCalculator.Domain.Entities.Tax;
using CongestionTaxCalculator.Domain.FilterSpecifications.Tax.Criteria;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Tax
{
    public class GetTaxByDynamicFilterSpecification : Specification<TaxRole>
    {
        private readonly GetTaxRoleByDynamicFilterDTO _filter;
        public GetTaxByDynamicFilterSpecification(GetTaxRoleByDynamicFilterDTO filter, params TaxRoleNavigationProperty[] navigationProperties)
        {
            _filter = filter;
            Query.Where(Criteria().ToExpression());
            navigationProperties.ToList().ForEach(AddNavigationProperty);
        }


        private void AddNavigationProperty(TaxRoleNavigationProperty taxRoleNavigationProperty)
        {
            switch (taxRoleNavigationProperty)
            {
                case TaxRoleNavigationProperty.TaxRoleRegions:
                    Query.Include(inc => inc.TaxRoleRegions)
                        .ThenInclude(inc => inc.Region)
                        .ThenInclude(inc => inc.TaxStations);
                    break;
                case TaxRoleNavigationProperty.TaxRoleVehicles:
                    Query.Include(inc => inc.TaxRoleVehicles);
                    break;
                case TaxRoleNavigationProperty.TaxScopes:
                    Query.Include(inc => inc.TaxScopes);
                    break;
                default:
                    break;
            }
        }
        private CriteriaSpecification<TaxRole> Criteria()
        {
            return new CheckTaxOnCriteria(_filter.TaxOn)
                .And(new CheckTaxRoleIdCriteria(_filter.TaxRoleId));
        }
    }

    

    public enum TaxRoleNavigationProperty
    {
        TaxRoleRegions,
        TaxRoleVehicles,
        TaxScopes
    }
}
