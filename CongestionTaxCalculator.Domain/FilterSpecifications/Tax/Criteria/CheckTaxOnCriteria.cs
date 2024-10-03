using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using CongestionTaxCalculator.Domain.Entities.Tax;
using System.Linq.Expressions;

namespace CongestionTaxCalculator.Domain.FilterSpecifications.Tax.Criteria
{
    public class CheckTaxOnCriteria : CriteriaSpecification<TaxRole>
    {
        private readonly string? _taxOn;

        public CheckTaxOnCriteria(string? taxOn)
        {
            _taxOn = taxOn;
        }
        public override Expression<Func<TaxRole, bool>> ToExpression()
        {
            if (_taxOn == null || !_taxOn.HasValue())
            {
                return current => true;
            }
            return current => current.TaxOn == _taxOn;
        }
    }
}
