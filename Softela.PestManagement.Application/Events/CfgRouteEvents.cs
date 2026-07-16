namespace Softela.PestManagement.Application.Events;

public sealed record CfgRouteCreatedEvent(int CfgRouteId, int TenantId, int CfgEmployeeId) : IDomainEvent;
public sealed record CfgRouteUpdatedEvent(int CfgRouteId, int TenantId, int CfgEmployeeId) : IDomainEvent;
public sealed record CfgRouteDeletedEvent(int CfgRouteId, int TenantId) : IDomainEvent;
