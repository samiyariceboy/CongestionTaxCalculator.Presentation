using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entities.Receiption;
using CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects;

namespace CongestionTaxCalculator.Domain.Entities.Tax
{
    public class TaxScope : BaseEntity
    {
        #region Ctors
        private TaxScope()
        {
            
        }
        public TaxScope(int year, Guid taxRoleId, TimeSpan fromTime, TimeSpan toTime, TaxAmount taxAmount)
        {
            Year = year;
            TaxRoleId = taxRoleId;
            FromTime = fromTime;
            ToTime = toTime;
            TaxAmount = taxAmount;
        }
        #endregion

        #region Propeteis
        public Guid TaxRoleId { get; private set; }

        public int Year { get; private set; }

        public TimeSpan FromTime { get; private set; }
        public TimeSpan ToTime { get; private set; }

        public TaxAmount TaxAmount { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual TaxRole TaxRole { get; private set; }
        #endregion

        #region ICollections
        private readonly List<TaxReceipt> _taxReceipts;
        public virtual IReadOnlyCollection<TaxReceipt> TaxReceipts => _taxReceipts;
        #endregion
        #endregion

        #region Methods

        #endregion
    }

    public enum TaxScopeType
    {
        SpecificTime,
    }
}
