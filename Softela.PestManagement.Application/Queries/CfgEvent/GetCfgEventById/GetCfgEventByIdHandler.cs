using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEventById;

public class GetCfgEventByIdHandler : IRequestHandler<GetCfgEventByIdRequest, GetCfgEventByIdResponse>
{
    private readonly ICfgEventRepository _cfgEventRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgEventByIdHandler(ICfgEventRepository cfgEventRepository, ITenantContext tenantContext)
    {
        _cfgEventRepository = cfgEventRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgEventByIdResponse> Handle(GetCfgEventByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgEvent = await _cfgEventRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgEvent {request.Id} not found.");

        return new GetCfgEventByIdResponse
        {
            Data = GetCfgEventByIdMapper.ToDto(cfgEvent)
        };
    }
}
