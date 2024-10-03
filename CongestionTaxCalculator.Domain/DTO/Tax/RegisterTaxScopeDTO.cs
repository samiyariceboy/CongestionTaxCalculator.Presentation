using CongestionTaxCalculator.Domain.Entities.Tax.ValueObjects;

namespace CongestionTaxCalculator.Domain.DTO.Tax
{
    public class RegisterTaxScopeDTO 
    {
        public required Guid TaxRoleId { get; init; }
        public required DateTime FromDate { get; init; }
        public required DateTime ToDate { get; init; }

        public required TaxAmount TaxAmount { get; init; }
    }
}
