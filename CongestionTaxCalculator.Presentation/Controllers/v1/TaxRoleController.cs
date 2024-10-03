using Mapster;
using Microsoft.AspNetCore.Mvc;
using CongestionTaxCalculator.Domain.DTO.Tax;
using CongestionTaxCalculator.Application.Models;
using CongestionTaxCalculator.Domain.Services.TaxDomainServices;

namespace CongestionTaxCalculator.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class TaxRoleController(ITaxDomainService taxDomainService) : BaseController
    {
        private readonly ITaxDomainService _taxDomainService = taxDomainService;

        [HttpGet("[action]")]
        public virtual async Task<ActionResult> GetTaxRoles([FromQuery]GetTaxRoleDTO getTaxRoleDTO, CancellationToken cancellationToken)
        {
            var result = await _taxDomainService.GetTaxRoleByDynamicFilter
                (getTaxRoleDTO.Adapt<GetTaxRoleByDynamicFilterDTO>(), cancellationToken);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<ActionResult<TaxRoleSelectedDTO>> CreateNewTaxRole(CreateNewTaxRoleDTO createNewTaxRoleDTO, CancellationToken cancellationToken)
        {
            var result = await _taxDomainService.CreateNewTaxRole(createNewTaxRoleDTO, cancellationToken);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<ActionResult> AssignTaxRoleToTheRegion(Guid taxRoleId, Guid regionId, CancellationToken cancellationToken)
        {
            await _taxDomainService.AssignTaxRoleToTheRegion(taxRoleId, regionId, cancellationToken);
            return Ok();
        }

        [HttpPost("[action]")]
        public virtual async Task<ActionResult> AssignTaxRoleToTheVehicle(Guid taxRoleId, Guid vehicleId, CancellationToken cancellationToken)
        {
            await _taxDomainService.AssignTaxRoleToTheVehicle(taxRoleId, vehicleId, cancellationToken);
            return Ok();
        }

    }
}
