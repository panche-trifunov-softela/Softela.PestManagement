namespace Softela.PestManagement.Application.Events;

public sealed record CfgEmployeeCreatedEvent(int CfgEmployeeId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgEmployeeUpdatedEvent(int CfgEmployeeId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgEmployeeDeletedEvent(int CfgEmployeeId, int TenantId) : IDomainEvent;
