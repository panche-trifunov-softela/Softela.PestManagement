using MediatR;

namespace Softela.PestManagement.Application.Queries.Tenant.GetTenants;

public sealed record GetTenantsRequest : IRequest<GetTenantsResponse>;
