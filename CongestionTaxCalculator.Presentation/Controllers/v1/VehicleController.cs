using CongestionTaxCalculator.Application.Models;
using CongestionTaxCalculator.Domain.DTO.Vehicle;
using Microsoft.AspNetCore.Mvc;
using CongestionTaxCalculator.Domain.Services.VehicleDomainServices;

namespace CongestionTaxCalculator.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class VehicleController : BaseController
    {
        private readonly IVehicleDomainService _vehicleDomainService;

        public VehicleController(IVehicleDomainService vehicleDomainService)
        {
            _vehicleDomainService = vehicleDomainService;
        }

        [HttpGet("[action]")]
        public virtual async Task<ActionResult> GetVehiclesByDynamicFilter([FromQuery] GetVehiclesDTO getVehiclesDTO, CancellationToken cancellationToken) 
        {
            //TODO: Get Vehicles 
            return Ok();
        } 

        [HttpPost("[action]")]
        public virtual async Task<ActionResult> RegisterLicensePlate(CreateLicensePlateDTO createLicensePlateDTo, CancellationToken cancellationToken)
        {
            await _vehicleDomainService.RegisterLicensePlate(createLicensePlateDTo, cancellationToken);
            return Ok();
        }
    }
}
