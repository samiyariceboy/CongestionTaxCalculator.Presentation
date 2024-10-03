using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Utilities;
using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.Entities.Tax;
using Microsoft.VisualBasic.FileIO;

namespace CongestionTaxCalculator.Domain.Entities.Regions
{
    public class Region : AggregateRoot<Guid>, ICloneable
    {
        #region Ctors
        private Region() { }
        public Region(string regionName)
        {
            RegionName = regionName;
        }
        #endregion

        #region  Propeteis
        public string RegionName { get; private set; }
        #endregion

        #region Relations
        #region ICollection
        public readonly List<TaxRoleRegion> _taxRoleRegions;
        public virtual IReadOnlyCollection<TaxRoleRegion> TaxRoleRegions => _taxRoleRegions;

        public readonly List<TaxStation> _taxStations;
        public virtual IReadOnlyCollection<TaxStation> TaxStations => _taxStations;

        public object Clone(CustomDateFormat customDateFormat)
        {
            return new RegionSelectedDto
            {
                RegionId = Id,
                RegionName = RegionName,
                CreateDate = CreateDate.ConvertToCustomDate(customDateFormat)
            };
        }
        public object Clone()
        {
            return new RegionSelectedDto
            {
                RegionName = RegionName,
            };
        }
        #endregion
        #endregion

        #region Methods
        public bool AddTaxStation(string stationName, double longitude, double latitude)
        {
            if (_taxStations.Any(a => a.Latitude == latitude && a.Longitude == longitude))
            {
                return false;
            }
            _taxStations.Add(new TaxStation(Id, stationName, longitude, latitude));
            return true;
        }
        #endregion
    }
}
