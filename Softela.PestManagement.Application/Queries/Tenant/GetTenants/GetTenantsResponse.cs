using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Queries.Tenant.GetTenants;

public sealed record GetTenantsResponse
{
    public List<Domain.Entities.Tenant> Data { get; init; }
}
