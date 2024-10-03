using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entities.Regions;

namespace CongestionTaxCalculator.Domain.Entities.Tax
{
    public class TaxRoleRegion : BaseEntity
    {
        #region Ctors
        private TaxRoleRegion()
        {
            
        }
        public TaxRoleRegion(Guid taxRoleId, Guid regionId)
        {
            TaxRoleId = taxRoleId;
            RegionId = regionId;
        }
        #endregion

        #region  Propeteis
        public Guid TaxRoleId { get; private set; }
        public Guid RegionId { get; private set; }
        #endregion

        #region Relations   
        #region ForeignKey
        public virtual TaxRole TaxRole { get; private set; }
        public virtual Region Region { get; private set; }
        #endregion

        #region ICollection

        #endregion
        #endregion

        #region Methods

        #endregion
    }
}
