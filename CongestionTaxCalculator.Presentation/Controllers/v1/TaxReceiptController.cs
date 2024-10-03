using CongestionTaxCalculator.Application.Models;
using CongestionTaxCalculator.Application.Services.ApplicationServices;
using CongestionTaxCalculator.Domain.DTO.Receiption;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class TaxReceiptController : BaseController
    {
        private readonly ITaxReceptionApplicationService _taxReceptionApplicationService;

        public TaxReceiptController(ITaxReceptionApplicationService taxReceptionApplicationService)
        {
            _taxReceptionApplicationService = taxReceptionApplicationService;
        }

        [HttpPost("[action]")]
        public virtual async Task<ActionResult> ReceiptTheTax(ReceiptTheTaxDTO receiptTheTaxDTO, CancellationToken cancellationToken)
        {
            await _taxReceptionApplicationService.ReceiptTheTax(receiptTheTaxDTO, cancellationToken);
            return Ok();
        }
    }
}
