using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimates;

public class GetCfgEstimatesHandler : IRequestHandler<GetCfgEstimatesRequest, GetCfgEstimatesResponse>
{
    private readonly ICfgEstimateRepository _cfgEstimateRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgEstimatesHandler(ICfgEstimateRepository cfgEstimateRepository, ITenantContext tenantContext)
    {
        _cfgEstimateRepository = cfgEstimateRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgEstimatesResponse> Handle(GetCfgEstimatesRequest request, CancellationToken cancellationToken)
    {
        var cfgEstimates = await _cfgEstimateRepository.GetByTenantIdAsync(_tenantContext.TenantId);

        return new GetCfgEstimatesResponse
        {
            Data = cfgEstimates.Select(GetCfgEstimatesMapper.ToDto).ToList()
        };
    }
}
