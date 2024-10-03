using MediatR;

namespace CongestionTaxCalculator.Domain.Common.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        public EventLocation EventLocation { get; }
    }

    public enum EventLocation
    {
        Internal,
        External
    }
}
