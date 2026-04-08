using System.Text.Json;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Infrastructure.Core.Outbox;

internal static class OutboxMessageFactory
{
    internal static OutboxMessage Create(IDomainEvent domainEvent) => new()
    {
        EventType = domainEvent.GetType().AssemblyQualifiedName!,
        Payload = JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
        OccurredAt = DateTimeOffset.UtcNow
    };
}
