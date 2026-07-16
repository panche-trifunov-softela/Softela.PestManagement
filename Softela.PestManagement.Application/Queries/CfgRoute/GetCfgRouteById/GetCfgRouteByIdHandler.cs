using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRouteById;

public class GetCfgRouteByIdHandler : IRequestHandler<GetCfgRouteByIdRequest, GetCfgRouteByIdResponse>
{
    private readonly ICfgRouteRepository _cfgRouteRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgRouteByIdHandler(ICfgRouteRepository cfgRouteRepository, ITenantContext tenantContext)
    {
        _cfgRouteRepository = cfgRouteRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgRouteByIdResponse> Handle(GetCfgRouteByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgRoute = await _cfgRouteRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgRoute {request.Id} not found.");

        return new GetCfgRouteByIdResponse
        {
            Data = GetCfgRouteByIdMapper.ToDto(cfgRoute)
        };
    }
}
