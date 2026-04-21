using System.Text.Json;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Outbox;

internal static class OutboxMessageFactory
{
    internal static OutboxMessage Create(IDomainEvent domainEvent, DateTimeOffset occurredAt) => new()
    {
        EventType = domainEvent.GetType().AssemblyQualifiedName!,
        Payload = JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
        OccurredAt = occurredAt
    };
}
