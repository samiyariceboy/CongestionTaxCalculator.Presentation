
using CongestionTaxCalculator.Domain.Common.DomainEvents;

namespace CongestionTaxCalculator.Domain.Common
{
    public interface IAggregateRoot : IEntity
    {
        void ClearDomainEvents();
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}