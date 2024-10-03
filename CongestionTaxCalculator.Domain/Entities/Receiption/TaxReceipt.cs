using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Domain.Entities.Tax;
using CongestionTaxCalculator.Domain.Entities.Vehicles;
namespace CongestionTaxCalculator.Domain.Entities.Receiption
{
    public class TaxReceipt : AggregateRoot<Guid>
    {
        #region Ctors
        private TaxReceipt() {}

        public TaxReceipt(Guid licensePlateId, Guid taxStationId, Guid taxScopeId,
            DateTime receiptTime)
        {
            LicensePlateId = licensePlateId;
            TaxStationId = taxStationId;
            TaxScopeId = taxScopeId;
            ReceiptTime = receiptTime;
        }
        #endregion

        #region Propeties
        public Guid LicensePlateId { get; private set; }
        public Guid TaxStationId { get; private set; }
        public Guid TaxScopeId { get; private set; }


        public DateTime ReceiptTime { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual LicensePlate LicensePlate { get; private set; }
        public virtual TaxStation TaxStation { get; private set; }
        public virtual TaxScope TaxScope { get; private set; }
        #endregion

        #region ICollection

        #endregion
        #endregion

        #region Methods

        #endregion
    }
}
