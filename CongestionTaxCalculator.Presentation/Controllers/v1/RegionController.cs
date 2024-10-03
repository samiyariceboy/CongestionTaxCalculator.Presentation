using CongestionTaxCalculator.Application.Models;
using CongestionTaxCalculator.Domain.DTO.Region;
using CongestionTaxCalculator.Domain.Services.TaxDomainServices;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class RegionController : BaseController
    {
        private readonly ITaxDomainService _taxDomainService;

        public RegionController(ITaxDomainService taxDomainService)
        {
            _taxDomainService = taxDomainService;
        }

        [HttpGet("[action]")]
        public virtual async Task<ActionResult<IEnumerable<RegionSelectedDto>>> GetRegionsByDynamicFilter([FromQuery]GetRegionDTO getRegionDTO, CancellationToken cancellationToken)
        {
            var result = await _taxDomainService.GetRegionByDynamicFilter(
                getRegionDTO.Adapt<GetRegionByDynamicFilterDTO>(), cancellationToken);
            return Ok(result);
        }

        
    }
}
