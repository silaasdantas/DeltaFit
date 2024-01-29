using DeltaFit.Api.Domain.Primitives;
using MediatR;

namespace DeltaFit.Api.Application.Abstractions.Messaging
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
