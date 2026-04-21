using System.Text.Json;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Infrastructure.Core.Outbox;

internal static class OutboxMessageFactory
{
    private static string GetStableEventType(Type eventType)
    {
        var fullName = eventType.FullName ?? eventType.Name;
        var assemblyName = eventType.Assembly.GetName().Name ?? string.Empty;

        return string.IsNullOrWhiteSpace(assemblyName)
            ? fullName
            : $"{fullName}, {assemblyName}";
    }

    internal static OutboxMessage Create(IDomainEvent domainEvent) => new()
    {
        EventType = GetStableEventType(domainEvent.GetType()),
        Payload = JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
        OccurredAt = DateTimeOffset.UtcNow
    };
}
