using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IOutboxRepository
{
    Task InsertAsync(OutboxMessage message);
    Task<List<OutboxMessage>> GetUnprocessedAsync(int batchSize, DateTimeOffset now, CancellationToken cancellationToken = default);
    Task MarkAsProcessedAsync(long id, DateTimeOffset processedAt, CancellationToken cancellationToken = default);
    Task MarkAsFailedAsync(long id, string error, CancellationToken cancellationToken = default);
}
