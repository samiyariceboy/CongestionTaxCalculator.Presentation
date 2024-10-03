using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entities.Receiption;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Domain.Entities.Tax;

namespace CongestionTaxCalculator.Domain.Entities.Vehicles
{
    public class LicensePlate : BaseEntity
    {

        #region Ctors
        private LicensePlate() {}

        public LicensePlate(Guid vehicleId, string vehicleOwnerName, string vehicleOwnerNationalCode, string licensePlateNumber)
        {
            VehicleId = vehicleId;
            VehicleOwnerName = vehicleOwnerName;
            VehicleOwnerNationalCode = vehicleOwnerNationalCode;
            LicensePlateNumber = licensePlateNumber;
        }
        #endregion

        #region Properties
        public string VehicleOwnerName { get; private set; }
        public string VehicleOwnerNationalCode { get; private set; }
        public string LicensePlateNumber { get; private set; }
        public Guid VehicleId { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual Vehicle Vehicle { get; private set; }
        #endregion

        #region ICollection
        private readonly List<TaxReceipt> _taxReceipts;
        public virtual IReadOnlyCollection<TaxReceipt> TaxReceipts => _taxReceipts;
        #endregion
        #endregion

        #region Methods 
        public TaxReceipt ReceiptTheTax(TaxStation taxStation, TaxScope taxScope, DateTime receiptTime)
        {
            var taxReceipt = new TaxReceipt(Id, taxStation.Id, taxScope.Id, receiptTime);
            _taxReceipts.Add(taxReceipt);
            return taxReceipt;
        }
        #endregion
    }
}
