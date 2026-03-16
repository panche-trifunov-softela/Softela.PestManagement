using MediatR;

namespace Softela.PestManagement.Application.Queries.Tenant.GetTenantById;

public sealed record GetTenantByIdRequest : IRequest<GetTenantByIdResponse>
{
    public int Id { get; init; }
}
