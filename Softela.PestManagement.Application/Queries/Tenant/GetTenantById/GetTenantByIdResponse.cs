namespace Softela.PestManagement.Application.Queries.Tenant.GetTenantById;

public sealed record GetTenantByIdResponse
{
    public Domain.Entities.Tenant Data { get; init; }
}
