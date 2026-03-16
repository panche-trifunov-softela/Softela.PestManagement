using MediatR;

namespace Softela.PestManagement.Application.Commands.Tenant.UpdateTenant;

public sealed record UpdateTenantRequest : IRequest<bool>
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Slug { get; init; }
    public bool IsActive { get; init; }
}
