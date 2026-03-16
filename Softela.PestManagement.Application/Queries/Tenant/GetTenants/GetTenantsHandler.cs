using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Tenant.GetTenants;

public class GetTenantsHandler : IRequestHandler<GetTenantsRequest, GetTenantsResponse>
{
    private readonly ITenantRepository _tenantRepository;

    public GetTenantsHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<GetTenantsResponse> Handle(GetTenantsRequest request, CancellationToken cancellationToken)
    {
        var tenants = await _tenantRepository.GetAllAsync();
        return new GetTenantsResponse { Data = tenants };
    }
}
