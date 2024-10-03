using CongestionTaxCalculator.Domain.DTO.Receiption;
using CongestionTaxCalculator.Domain.Entities.Tax;

namespace CongestionTaxCalculator.Domain.Entities.Receiption
{
    public interface ILawLimitationTaxReceipts
    {
        (bool IsReceiptable, TaxScope? TaxScope) ShouldTaxBeReceiptable(IEnumerable<TaxScope> taxScopes, IEnumerable<TaxReceipt> TaxsReceipted, ReceiptTheTaxDTO newTaxReceiption);
    }
}
