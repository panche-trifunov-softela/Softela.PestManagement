using System.Data;
using Dapper;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Infrastructure.Database.Dapper;

namespace Softela.PestManagement.Infrastructure.Database.Repositories;

public class OutboxRepository : IOutboxRepository
{
    private readonly IDapperDataContext _dapperDataContext;

    public OutboxRepository(IDapperDataContext dapperDataContext)
    {
        _dapperDataContext = dapperDataContext;
    }

    public async Task InsertAsync(OutboxMessage message)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_event_type", message.EventType, DbType.String);
        parameters.Add("p_payload", message.Payload, DbType.String);
        parameters.Add("p_occurred_at", message.OccurredAt, DbType.DateTimeOffset);

        await _dapperDataContext.Connection!.ExecuteAsync(
            sql: "INSERT INTO OutboxMessages (EventType, Payload, OccurredAt) VALUES (@p_event_type, @p_payload::jsonb, @p_occurred_at)",
            param: parameters,
            commandType: CommandType.Text,
            transaction: _dapperDataContext.Transaction
        ).ConfigureAwait(false);
    }

    public async Task<List<OutboxMessage>> GetUnprocessedAsync(int batchSize, DateTimeOffset now, CancellationToken cancellationToken = default)
    {
        var staleThreshold = now.AddMinutes(-5);

        var parameters = new DynamicParameters();
        parameters.Add("batch_size", batchSize, DbType.Int32);
        parameters.Add("claimed_at", now, DbType.DateTimeOffset);
        parameters.Add("stale_threshold", staleThreshold, DbType.DateTimeOffset);

        const string sql = """
            UPDATE OutboxMessages
            SET ClaimedAt = @claimed_at
            WHERE Id IN (
                SELECT Id FROM OutboxMessages
                WHERE ProcessedAt IS NULL
                  AND Error IS NULL
                  AND (ClaimedAt IS NULL OR ClaimedAt < @stale_threshold)
                ORDER BY OccurredAt
                LIMIT @batch_size
                FOR UPDATE SKIP LOCKED
            )
            RETURNING Id, EventType, Payload, OccurredAt, ClaimedAt, ProcessedAt, Error
            """;

        var command = new CommandDefinition(
            commandText: sql,
            parameters: parameters,
            transaction: _dapperDataContext.Transaction,
            commandType: CommandType.Text,
            cancellationToken: cancellationToken
        );

        var messages = await _dapperDataContext.Connection!.QueryAsync<OutboxMessage>(command).ConfigureAwait(false);
        return messages.ToList();
    }

    public async Task MarkAsProcessedAsync(long id, DateTimeOffset processedAt, CancellationToken cancellationToken = default)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", id, DbType.Int64);
        parameters.Add("p_processed_at", processedAt, DbType.DateTimeOffset);

        var command = new CommandDefinition(
            commandText: "UPDATE OutboxMessages SET ProcessedAt = @p_processed_at WHERE Id = @p_id",
            parameters: parameters,
            transaction: _dapperDataContext.Transaction,
            commandType: CommandType.Text,
            cancellationToken: cancellationToken
        );

        await _dapperDataContext.Connection!.ExecuteAsync(command).ConfigureAwait(false);
    }

    public async Task MarkAsFailedAsync(long id, string error, CancellationToken cancellationToken = default)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_id", id, DbType.Int64);
        parameters.Add("p_error", error, DbType.String);

        var command = new CommandDefinition(
            commandText: "UPDATE OutboxMessages SET Error = @p_error WHERE Id = @p_id",
            parameters: parameters,
            transaction: _dapperDataContext.Transaction,
            commandType: CommandType.Text,
            cancellationToken: cancellationToken
        );

        await _dapperDataContext.Connection!.ExecuteAsync(command).ConfigureAwait(false);
    }
}
