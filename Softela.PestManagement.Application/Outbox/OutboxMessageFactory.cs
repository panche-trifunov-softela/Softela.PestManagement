using System.Text.Json;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Outbox;

internal static class OutboxMessageFactory
{
    internal static OutboxMessage Create(IDomainEvent domainEvent, DateTimeOffset occurredAt)
    {
        var eventType = domainEvent.GetType();
        var stableEventType = $"{eventType.FullName}, {eventType.Assembly.GetName().Name}";

        return new OutboxMessage
        {
            EventType = stableEventType,
            Payload = JsonSerializer.Serialize(domainEvent, eventType),
            OccurredAt = occurredAt
        };
    }
}
