using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgPrograms;

public class GetCfgProgramsHandler : IRequestHandler<GetCfgProgramsRequest, GetCfgProgramsResponse>
{
    private readonly ICfgProgramRepository _cfgProgramRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgProgramsHandler(ICfgProgramRepository cfgProgramRepository, ITenantContext tenantContext)
    {
        _cfgProgramRepository = cfgProgramRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgProgramsResponse> Handle(GetCfgProgramsRequest request, CancellationToken cancellationToken)
    {
        var cfgPrograms = await _cfgProgramRepository.GetByTenantIdAsync(_tenantContext.TenantId);

        return new GetCfgProgramsResponse
        {
            Data = cfgPrograms.Select(GetCfgProgramsMapper.ToDto).ToList()
        };
    }
}
