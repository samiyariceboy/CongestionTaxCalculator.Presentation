using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Region.Criteria
{
    public class CheckRegionNameCriteria(string regionName) : CriteriaSpecification<Entities.Regions.Region>
    {
        private readonly string _regionName = regionName;

        public override Expression<Func<Entities.Regions.Region, bool>> ToExpression()
        {
            if (_regionName == null || !_regionName.HasValue())
            {
                return current => true;
            }
            return current => current.RegionName == _regionName;    
        }
    }
}
