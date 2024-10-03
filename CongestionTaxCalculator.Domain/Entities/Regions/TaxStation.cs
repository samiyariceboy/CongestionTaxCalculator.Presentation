using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entities.Receiption;

namespace CongestionTaxCalculator.Domain.Entities.Regions
{
    public class TaxStation : BaseEntity
    {
        #region Ctors
        private TaxStation()
        {

        }
        public TaxStation(Guid regionId, string stationName, double longitude, double latitude)
        {
            RegionId = regionId;
            StationName = stationName;
            Longitude = longitude;
            Latitude = latitude;
        }
        #endregion

        #region Properties
        public string StationName { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public Guid RegionId { get; set; }

        #endregion

        #region Relations
        #region ForeignKey
        public virtual Region Region { get; private set; }
        #endregion

        #region ICollection
        private readonly List<TaxReceipt> _taxReceipts;
        public virtual IReadOnlyCollection<TaxReceipt> TaxReceipts => _taxReceipts;
        #endregion
        #endregion

        #region Method

        #endregion
    }
}
