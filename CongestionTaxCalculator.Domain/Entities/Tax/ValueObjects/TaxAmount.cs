using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects
{
    public class TaxAmount : BaseValueObject
    {
        #region Ctors
        private TaxAmount() {}
        public TaxAmount(decimal amount, AmountUnit amountUnit)
        {
            Amount = amount;
            AmountUnit = amountUnit;
        }
        #endregion
        #region Propeties
        public decimal Amount { get; set; }
        public AmountUnit AmountUnit { get; set; }
        #endregion

        public override bool Equals(object obj)
        {
            var targetTaxAmount = obj as TaxAmount;
            if (targetTaxAmount != null && 
                targetTaxAmount.Amount == Amount && targetTaxAmount.AmountUnit == AmountUnit)
            {
                return true;
            }
            return false;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return AmountUnit;
        }
    }

    public enum AmountUnit
    {
        SEK
    }
}
