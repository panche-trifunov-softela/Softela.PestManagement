using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRoutes;

public class GetCfgRoutesHandler : IRequestHandler<GetCfgRoutesRequest, GetCfgRoutesResponse>
{
    private readonly ICfgRouteRepository _cfgRouteRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgRoutesHandler(ICfgRouteRepository cfgRouteRepository, ITenantContext tenantContext)
    {
        _cfgRouteRepository = cfgRouteRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgRoutesResponse> Handle(GetCfgRoutesRequest request, CancellationToken cancellationToken)
    {
        var cfgRoutes = await _cfgRouteRepository.GetByEmployeeIdAsync(request.CfgEmployeeId, _tenantContext.TenantId);

        return new GetCfgRoutesResponse
        {
            Data = cfgRoutes.Select(GetCfgRoutesMapper.ToDto).ToList()
        };
    }
}
