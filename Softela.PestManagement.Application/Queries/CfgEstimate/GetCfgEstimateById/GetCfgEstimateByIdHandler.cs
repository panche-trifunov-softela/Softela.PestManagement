using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimateById;

public class GetCfgEstimateByIdHandler : IRequestHandler<GetCfgEstimateByIdRequest, GetCfgEstimateByIdResponse>
{
    private readonly ICfgEstimateRepository _cfgEstimateRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgEstimateByIdHandler(ICfgEstimateRepository cfgEstimateRepository, ITenantContext tenantContext)
    {
        _cfgEstimateRepository = cfgEstimateRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgEstimateByIdResponse> Handle(GetCfgEstimateByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgEstimate = await _cfgEstimateRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgEstimate {request.Id} not found.");

        return new GetCfgEstimateByIdResponse
        {
            Data = GetCfgEstimateByIdMapper.ToDto(cfgEstimate)
        };
    }
}
