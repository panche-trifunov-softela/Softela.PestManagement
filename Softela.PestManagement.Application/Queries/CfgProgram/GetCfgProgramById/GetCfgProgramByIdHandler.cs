using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgProgramById;

public class GetCfgProgramByIdHandler : IRequestHandler<GetCfgProgramByIdRequest, GetCfgProgramByIdResponse>
{
    private readonly ICfgProgramRepository _cfgProgramRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgProgramByIdHandler(ICfgProgramRepository cfgProgramRepository, ITenantContext tenantContext)
    {
        _cfgProgramRepository = cfgProgramRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgProgramByIdResponse> Handle(GetCfgProgramByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgProgram = await _cfgProgramRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgProgram {request.Id} not found.");

        return new GetCfgProgramByIdResponse
        {
            Data = GetCfgProgramByIdMapper.ToDto(cfgProgram)
        };
    }
}
