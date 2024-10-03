using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Region.Criteria
{
    public class CheckRegionIdCriteria(Guid regionId) : CriteriaSpecification<Entities.Regions.Region>
    {
        private readonly Guid _regionId = regionId;

        public override Expression<Func<Entities.Regions.Region, bool>> ToExpression()
        {
            if (_regionId.GuidIsEmpty())
            {
                return current => true;
            }
            return current => current.Id == _regionId;
        }
    }
}
