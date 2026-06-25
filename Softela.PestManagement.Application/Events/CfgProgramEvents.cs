namespace Softela.PestManagement.Application.Events;

public sealed record CfgProgramCreatedEvent(int CfgProgramId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgProgramUpdatedEvent(int CfgProgramId, int TenantId, string Name) : IDomainEvent;
public sealed record CfgProgramDeletedEvent(int CfgProgramId, int TenantId) : IDomainEvent;
