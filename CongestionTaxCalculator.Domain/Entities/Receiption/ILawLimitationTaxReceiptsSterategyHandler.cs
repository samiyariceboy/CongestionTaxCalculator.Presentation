﻿
using CongestionTaxCalculator.Domain.DTO.Receiption;
using CongestionTaxCalculator.Domain.Entities.Regions;
using CongestionTaxCalculator.Domain.Entities.Tax;

namespace CongestionTaxCalculator.Domain.Entities.Receiption
{
    public interface ILawLimitationTaxReceiptsSterategyHandler
    {
        (bool IsReceiptable, TaxScope? TaxScope) ShouldTaxBeReceiptable(IEnumerable<TaxScope> taxScopes,
            IEnumerable<TaxReceipt> TaxsReceipted, TaxStation taxStation, ReceiptTheTaxDTO receiptTheTaxDTO);
    }
}