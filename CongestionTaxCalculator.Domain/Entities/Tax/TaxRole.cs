using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Exceptions;
using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.DTO.Tax;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects;
using CongestionTaxCalculator.Domain.Entities.Vehicles;

namespace CongestionTaxCalculator.Domain.Entities.Tax
{
    public class TaxRole : AggregateRoot<Guid>, ICloneable
    {
        #region Ctors
        private TaxRole(){}

        public TaxRole(string taxOn, string taxDescription,
            TaxAmount minimumAmount, TaxAmount maximumAmount)
        {
            TaxOn = taxOn;
            TaxDescription = taxDescription;
            MinimumAmount = minimumAmount;
            MaximumAmount = maximumAmount;
        }
        #endregion

        #region  Propeteis
        public string TaxOn { get; private set; }
        public TaxAmount MaximumAmount { get; private set; }
        public TaxAmount MinimumAmount { get; private set; }
        public string TaxDescription { get; private set; }
        #endregion

        #region Relations   
        #region ForeignKey

        #endregion

        #region ICollection
        public readonly List<TaxRoleRegion> _taxRoleRegions;
        public virtual IReadOnlyCollection<TaxRoleRegion> TaxRoleRegions => _taxRoleRegions;


        public readonly List<TaxRoleVehicle> _taxRoleVehicles;
        public virtual IReadOnlyCollection<TaxRoleVehicle> TaxRoleVehicles => _taxRoleVehicles;


        public readonly List<TaxScope> _taxScopes;
        public virtual IReadOnlyCollection<TaxScope> TaxScopes => _taxScopes;


        #endregion
        #endregion

        #region Methods
        public object Clone()
        {
            return new TaxRoleSelectedDTO
            {
                TaxRoleId = Id,
                TaxOn = TaxOn,
                TaxDescription = TaxDescription,
                MinimumAmount = MinimumAmount,
                MaximumAmount = MaximumAmount,
                RegionsIncludingTheTaxRole = TaxRoleRegions != null || TaxRoleRegions.Any() ?
               TaxRoleRegions.Select(s => s.Region.Clone() as RegionSelectedDto).ToList() : new List<RegionSelectedDto>()
            };
        }
        public void AssignTaxRoleToNewRegion(Region region)
        {
            if (!_taxRoleRegions.Any(a => a.RegionId == region.Id))
            {
                _taxRoleRegions.Add(new TaxRoleRegion(Id, region.Id));
            }
            else throw new AppException(ApiResultStatusCode.Confilict);
        }

        public void AssignTaxRoleToNewVehicle(Vehicle vehicle)
        {
            if (!_taxRoleVehicles.Any(a => a.Vehicle.Id == vehicle.Id))
            {
                _taxRoleVehicles.Add(new TaxRoleVehicle(Id, vehicle.Id));
            }
            else throw new AppException(ApiResultStatusCode.Confilict);
        }

        public bool AddTaxScope(TimeSpan fromDate, TimeSpan toDate, TaxAmount taxAmount)
        {
            if (_taxScopes.Any(a => a.FromTime == fromDate && a.ToTime == toDate && 
                                    a.TaxAmount.Equals(taxAmount)))
            {
                return false;
            }

            _taxScopes.Add(new TaxScope(2013, Id, fromDate, toDate, taxAmount));
            return true;
        }
        #endregion
    }
}
