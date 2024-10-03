using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entities.Vehicles;

namespace CongestionTaxCalculator.Domain.Entities.Tax
{
    public class TaxRoleVehicle : BaseEntity
    {
        #region Ctors
        private TaxRoleVehicle() {}
        public TaxRoleVehicle(Guid taxRoleId, Guid vehicleId)
        {
            TaxRoleId = taxRoleId;
            VehicleId = vehicleId;
        }
        #endregion

        #region Propeties
        public Guid VehicleId { get; private set; }
        public Guid TaxRoleId { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual Vehicle Vehicle { get; private set; }
        public virtual TaxRole TaxRole { get; private set; }
        #endregion
        #endregion

        #region Methods

        #endregion
    }
}
