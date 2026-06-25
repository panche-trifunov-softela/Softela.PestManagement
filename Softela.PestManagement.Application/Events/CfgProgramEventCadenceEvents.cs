namespace Softela.PestManagement.Application.Events;

public sealed record CfgProgramEventCadenceCreatedEvent(int CfgProgramEventCadenceId, int TenantId, int CfgProgramId) : IDomainEvent;
public sealed record CfgProgramEventCadenceUpdatedEvent(int CfgProgramEventCadenceId, int TenantId, int CfgProgramId) : IDomainEvent;
public sealed record CfgProgramEventCadenceDeletedEvent(int CfgProgramEventCadenceId, int TenantId) : IDomainEvent;
