namespace Softela.PestManagement.Application.Events;

public sealed record TenantFeatureUpsertedEvent(int TenantId, string FeatureKey, bool IsEnabled) : IDomainEvent;
