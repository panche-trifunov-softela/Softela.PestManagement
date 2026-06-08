namespace Softela.PestManagement.Application.Events;

public sealed record ProgramCreatedEvent(int ProgramId, int EstimateId) : IDomainEvent;
public sealed record ProgramUpdatedEvent(int ProgramId) : IDomainEvent;
public sealed record ProgramDeletedEvent(int ProgramId) : IDomainEvent;
