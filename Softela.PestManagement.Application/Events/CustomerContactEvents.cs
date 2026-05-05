namespace Softela.PestManagement.Application.Events;

public sealed record CustomerContactUpsertedEvent(int ContactId, int CustomerId, int TenantId) : IDomainEvent;
public sealed record CustomerContactPhoneUpsertedEvent(int PhoneId, int ContactId, int TenantId) : IDomainEvent;
public sealed record CustomerContactPhoneDeletedEvent(int ContactId, int TenantId) : IDomainEvent;
