namespace Softela.PestManagement.Application.Events;

public sealed record CfgEstimateCreatedEvent(int CfgEstimateId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgEstimateUpdatedEvent(int CfgEstimateId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgEstimateDeletedEvent(int CfgEstimateId, int TenantId) : IDomainEvent;
