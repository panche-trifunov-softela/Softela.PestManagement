namespace Softela.PestManagement.Application.Events;

public sealed record EstimateCreatedEvent(int EstimateId, int ServiceAddressId) : IDomainEvent;
public sealed record EstimateUpdatedEvent(int EstimateId, int ServiceAddressId) : IDomainEvent;
public sealed record EstimateDeletedEvent(int EstimateId) : IDomainEvent;
