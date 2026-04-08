namespace Softela.PestManagement.Application.Events;

public sealed record CustomerCreatedEvent(int CustomerId, int TenantId, string Name) : IDomainEvent;
public sealed record CustomerUpdatedEvent(int CustomerId, int TenantId, string Name) : IDomainEvent;
public sealed record CustomerDeletedEvent(int CustomerId, int TenantId) : IDomainEvent;
