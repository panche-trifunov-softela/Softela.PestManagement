using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadenceById;

public class GetCfgCadenceByIdHandler : IRequestHandler<GetCfgCadenceByIdRequest, GetCfgCadenceByIdResponse>
{
    private readonly ICfgCadenceRepository _cfgCadenceRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgCadenceByIdHandler(ICfgCadenceRepository cfgCadenceRepository, ITenantContext tenantContext)
    {
        _cfgCadenceRepository = cfgCadenceRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgCadenceByIdResponse> Handle(GetCfgCadenceByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgCadence = await _cfgCadenceRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgCadence {request.Id} not found.");

        return new GetCfgCadenceByIdResponse
        {
            Data = GetCfgCadenceByIdMapper.ToDto(cfgCadence)
        };
    }
}
