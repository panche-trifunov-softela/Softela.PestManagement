using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEvents;

public class GetCfgEventsHandler : IRequestHandler<GetCfgEventsRequest, GetCfgEventsResponse>
{
    private readonly ICfgEventRepository _cfgEventRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgEventsHandler(ICfgEventRepository cfgEventRepository, ITenantContext tenantContext)
    {
        _cfgEventRepository = cfgEventRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgEventsResponse> Handle(GetCfgEventsRequest request, CancellationToken cancellationToken)
    {
        var cfgEvents = await _cfgEventRepository.GetByTenantIdAsync(_tenantContext.TenantId);

        return new GetCfgEventsResponse
        {
            Data = cfgEvents.Select(GetCfgEventsMapper.ToDto).ToList()
        };
    }
}
