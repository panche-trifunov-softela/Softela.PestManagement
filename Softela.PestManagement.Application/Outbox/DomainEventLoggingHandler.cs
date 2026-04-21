using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Events;

namespace Softela.PestManagement.Application.Outbox;

// TODO: Temporary handler — replace with real per-event handlers and remove this file.
// Not registered in production (see BuilderExtensions).
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
        _logger.LogDebug("[Outbox] Event consumed: {EventType}", typeof(TEvent).Name);
        return Task.CompletedTask;
    }
}
