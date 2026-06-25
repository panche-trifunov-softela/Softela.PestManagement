using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadences;

public class GetCfgCadencesHandler : IRequestHandler<GetCfgCadencesRequest, GetCfgCadencesResponse>
{
    private readonly ICfgCadenceRepository _cfgCadenceRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgCadencesHandler(ICfgCadenceRepository cfgCadenceRepository, ITenantContext tenantContext)
    {
        _cfgCadenceRepository = cfgCadenceRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgCadencesResponse> Handle(GetCfgCadencesRequest request, CancellationToken cancellationToken)
    {
        var cfgCadences = await _cfgCadenceRepository.GetByTenantIdAsync(_tenantContext.TenantId);

        return new GetCfgCadencesResponse
        {
            Data = cfgCadences.Select(GetCfgCadencesMapper.ToDto).ToList()
        };
    }
}
