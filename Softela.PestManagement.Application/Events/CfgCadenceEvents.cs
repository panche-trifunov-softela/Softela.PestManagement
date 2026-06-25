namespace Softela.PestManagement.Application.Events;

public sealed record CfgCadenceCreatedEvent(int CfgCadenceId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgCadenceUpdatedEvent(int CfgCadenceId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgCadenceDeletedEvent(int CfgCadenceId, int TenantId) : IDomainEvent;
