namespace Softela.PestManagement.Application.Events;

public sealed record ServiceAddressCreatedEvent(int ServiceAddressId, int CustomerId, int TenantId) : IDomainEvent;
public sealed record ServiceAddressUpdatedEvent(int ServiceAddressId, int CustomerId, int TenantId) : IDomainEvent;
public sealed record ServiceAddressDeletedEvent(int ServiceAddressId, int TenantId) : IDomainEvent;
