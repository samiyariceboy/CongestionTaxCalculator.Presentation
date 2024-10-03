using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.Exceptions;
using CongestionTaxCalculator.Domain.Entities.Tax;

namespace CongestionTaxCalculator.Domain.Entities.Vehicles
{
    public class Vehicle : AggregateRoot<Guid>
    {
        #region Ctors
        private Vehicle() { }
        public Vehicle(string vehicleName)
        {
            VehicleName = vehicleName;
        }
        #endregion

        #region  Propeteis
        public string VehicleName { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public string? Model { get; private set; }
        #endregion

        #region Relations
        public readonly List<TaxRoleVehicle> _taxRoleVehicles;
        public virtual IReadOnlyCollection<TaxRoleVehicle> TaxRoleVehicles => _taxRoleVehicles;

        public readonly List<LicensePlate> _licensePlates;
        public virtual IReadOnlyCollection<LicensePlate> LicensePlates => _licensePlates;

        #endregion

        #region Methods
        public void AddLicensePlate(LicensePlate licensePlate)
        {
            if (LicensePlates.Any(a => a.LicensePlateNumber == licensePlate.LicensePlateNumber))
            {
                throw new AppException(ApiResultStatusCode.Confilict);
            }

            _licensePlates.Add(licensePlate);
        }
        #endregion
    }

    public enum VehicleType
    {
        Rideing,
        Cargo
    }
}
