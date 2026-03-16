using MediatR;

namespace Softela.PestManagement.Application.Commands.Tenant.UpsertFeature;

public sealed record UpsertFeatureRequest : IRequest<bool>
{
    public int TenantId { get; init; }
    public string FeatureKey { get; init; }
    public bool IsEnabled { get; init; }
}
