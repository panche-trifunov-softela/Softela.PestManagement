using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Events;
using System.Text.Json;

namespace Softela.PestManagement.Application.Outbox;

// TODO: Temporary handler — replace with real per-event handlers and remove this file.
internal sealed class DomainEventLoggingHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : class, IDomainEvent
{
    private readonly ILogger<DomainEventLoggingHandler<TEvent>> _logger;

    public DomainEventLoggingHandler(ILogger<DomainEventLoggingHandler<TEvent>> logger)
    {
        _logger = logger;
    }

    public Task Handle(TEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "[Outbox] Event consumed: {EventType} | {Payload}",
            typeof(TEvent).Name,
            JsonSerializer.Serialize(notification));

        return Task.CompletedTask;
    }
}
