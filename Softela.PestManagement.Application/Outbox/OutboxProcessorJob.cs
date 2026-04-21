using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Softela.PestManagement.Application.Repositories;
using System.Text.Json;

namespace Softela.PestManagement.Application.Outbox;

public sealed class OutboxProcessorJob : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<OutboxProcessorJob> _logger;
    private readonly IOptions<OutboxOptions> _options;

    public OutboxProcessorJob(
        IServiceScopeFactory scopeFactory,
        ILogger<OutboxProcessorJob> logger,
        IOptions<OutboxOptions> options)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessBatchAsync(stoppingToken);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _logger.LogError(ex, "Unhandled error during outbox processing.");
            }

            var interval = TimeSpan.FromSeconds(_options.Value.IntervalSeconds);
            await Task.Delay(interval, stoppingToken).ConfigureAwait(false);
        }
    }

    private async Task ProcessBatchAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var outboxRepository = scope.ServiceProvider.GetRequiredService<IOutboxRepository>();
        var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

        var now = DateTimeOffset.UtcNow;
        var messages = await outboxRepository.GetUnprocessedAsync(_options.Value.BatchSize, now, cancellationToken);

        foreach (var message in messages)
        {
            try
            {
                var type = Type.GetType(message.EventType);
                if (type is null)
                {
                    _logger.LogWarning("Cannot resolve event type '{EventType}' for outbox message {Id}.", message.EventType, message.Id);
                    await outboxRepository.MarkAsFailedAsync(message.Id, $"Cannot resolve type '{message.EventType}'.", cancellationToken);
                    continue;
                }

                var notification = (INotification?)JsonSerializer.Deserialize(message.Payload, type);
                if (notification is null)
                {
                    await outboxRepository.MarkAsFailedAsync(message.Id, "Payload deserialization returned null.", cancellationToken);
                    continue;
                }

                await publisher.Publish(notification, cancellationToken);
                await outboxRepository.MarkAsProcessedAsync(message.Id, now, cancellationToken);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to process outbox message {Id}.", message.Id);
                await outboxRepository.MarkAsFailedAsync(message.Id, ex.Message, cancellationToken);
            }
        }
    }
}
