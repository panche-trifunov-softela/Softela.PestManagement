namespace Softela.PestManagement.Application.Events;

public sealed record CfgProgramEventCadenceCreatedEvent(int CfgProgramEventCadenceId, int CfgProgramId) : IDomainEvent;
public sealed record CfgProgramEventCadenceUpdatedEvent(int CfgProgramEventCadenceId, int CfgProgramId) : IDomainEvent;
public sealed record CfgProgramEventCadenceDeletedEvent(int CfgProgramEventCadenceId) : IDomainEvent;
