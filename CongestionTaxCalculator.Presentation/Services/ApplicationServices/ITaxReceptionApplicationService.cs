using CongestionTaxCalculator.Domain.DTO.Receiption;

namespace CongestionTaxCalculator.Application.Services.ApplicationServices
{
    public interface ITaxReceptionApplicationService
    {
        Task ReceiptTheTax(ReceiptTheTaxDTO receiptTheTaxDTO, CancellationToken cancellationToken);
    }
}