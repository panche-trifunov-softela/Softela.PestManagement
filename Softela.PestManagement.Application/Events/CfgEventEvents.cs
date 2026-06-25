namespace Softela.PestManagement.Application.Events;

public sealed record CfgEventCreatedEvent(int CfgEventId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgEventUpdatedEvent(int CfgEventId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgEventDeletedEvent(int CfgEventId, int TenantId) : IDomainEvent;
