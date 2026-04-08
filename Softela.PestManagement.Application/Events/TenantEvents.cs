namespace Softela.PestManagement.Application.Events;

public sealed record TenantUpsertedEvent(int TenantId, string Name, string Slug) : IDomainEvent;
