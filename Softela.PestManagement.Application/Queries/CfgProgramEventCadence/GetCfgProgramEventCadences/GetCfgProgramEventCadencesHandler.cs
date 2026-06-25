using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadences;

public class GetCfgProgramEventCadencesHandler : IRequestHandler<GetCfgProgramEventCadencesRequest, GetCfgProgramEventCadencesResponse>
{
    private readonly ICfgProgramEventCadenceRepository _cfgProgramEventCadenceRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgProgramEventCadencesHandler(ICfgProgramEventCadenceRepository cfgProgramEventCadenceRepository, ITenantContext tenantContext)
    {
        _cfgProgramEventCadenceRepository = cfgProgramEventCadenceRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgProgramEventCadencesResponse> Handle(GetCfgProgramEventCadencesRequest request, CancellationToken cancellationToken)
    {
        var cfgProgramEventCadences = await _cfgProgramEventCadenceRepository.GetByProgramIdAsync(request.CfgProgramId, _tenantContext.TenantId);

        return new GetCfgProgramEventCadencesResponse
        {
            Data = cfgProgramEventCadences.Select(GetCfgProgramEventCadencesMapper.ToDto).ToList()
        };
    }
}
