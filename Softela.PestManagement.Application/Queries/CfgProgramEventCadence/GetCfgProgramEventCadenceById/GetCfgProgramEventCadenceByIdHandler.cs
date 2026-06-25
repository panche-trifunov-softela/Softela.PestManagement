using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadenceById;

public class GetCfgProgramEventCadenceByIdHandler : IRequestHandler<GetCfgProgramEventCadenceByIdRequest, GetCfgProgramEventCadenceByIdResponse>
{
    private readonly ICfgProgramEventCadenceRepository _cfgProgramEventCadenceRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgProgramEventCadenceByIdHandler(ICfgProgramEventCadenceRepository cfgProgramEventCadenceRepository, ITenantContext tenantContext)
    {
        _cfgProgramEventCadenceRepository = cfgProgramEventCadenceRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgProgramEventCadenceByIdResponse> Handle(GetCfgProgramEventCadenceByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgProgramEventCadence = await _cfgProgramEventCadenceRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgProgramEventCadence {request.Id} not found.");

        return new GetCfgProgramEventCadenceByIdResponse
        {
            Data = GetCfgProgramEventCadenceByIdMapper.ToDto(cfgProgramEventCadence)
        };
    }
}
