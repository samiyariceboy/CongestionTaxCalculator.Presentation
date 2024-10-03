using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Domain.DTO.Receiption;
using CongestionTaxCalculator.Domain.Entities.Tax;

namespace CongestionTaxCalculator.Domain.Entities.Receiption
{
    public class LawLimitationTaxReceiptsSterategyHandler(IEnumerable<ILawLimitationTaxReceipts> taxReceiptsSterategies)
        : ILawLimitationTaxReceiptsSterategyHandler, IScopedDependency
    {
        private readonly IEnumerable<ILawLimitationTaxReceipts> _taxReceiptsSterategies = taxReceiptsSterategies;

        public (bool IsReceiptable, TaxScope? TaxScope) ShouldTaxBeReceiptable(IEnumerable<TaxScope> taxScopes, IEnumerable<TaxReceipt> TaxsReceipted, ReceiptTheTaxDTO newTaxReceiption)
        {
            (bool, TaxScope?) isReceiptable = (false, null);
            foreach (var taxReceiptSterategy in _taxReceiptsSterategies)
            {
                isReceiptable = taxReceiptSterategy.ShouldTaxBeReceiptable(taxScopes, TaxsReceipted, newTaxReceiption);
            }
            return isReceiptable;
        }
    }
}
