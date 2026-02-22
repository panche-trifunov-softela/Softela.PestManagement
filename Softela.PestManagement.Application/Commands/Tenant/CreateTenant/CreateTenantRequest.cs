using MediatR;

namespace Softela.PestManagement.Application.Commands.Tenant.CreateTenant;

public sealed record CreateTenantRequest : IRequest<int>
{
    public string Name { get; init; }
    public string Slug { get; init; }
}
