using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IOutboxRepository
{
    Task InsertAsync(OutboxMessage message);
    Task<List<OutboxMessage>> GetUnprocessedAsync(int batchSize, DateTimeOffset now, TimeSpan stalenessWindow, CancellationToken cancellationToken = default);
    Task MarkAsProcessedAsync(long id, Guid claimToken, DateTimeOffset processedAt, CancellationToken cancellationToken = default);
    Task MarkAsFailedAsync(long id, Guid claimToken, string error, CancellationToken cancellationToken = default);
}
