using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using CongestionTaxCalculator.Domain.Entities.Tax;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Tax.Criteria
{
    public class CheckTaxRoleIdCriteria : CriteriaSpecification<TaxRole>
    {
        private readonly Guid _taxRoleId;

        public CheckTaxRoleIdCriteria(Guid taxRoleId)
        {
            _taxRoleId = taxRoleId;
        }

        public override Expression<Func<TaxRole, bool>> ToExpression()
        {
            if (_taxRoleId.GuidIsEmpty())
            {
                return current => true;
            }
            return current => current.Id == _taxRoleId;
        }
    }
}
