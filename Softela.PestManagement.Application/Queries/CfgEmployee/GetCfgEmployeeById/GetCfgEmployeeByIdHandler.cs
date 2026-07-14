using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployeeById;

public class GetCfgEmployeeByIdHandler : IRequestHandler<GetCfgEmployeeByIdRequest, GetCfgEmployeeByIdResponse>
{
    private readonly ICfgEmployeeRepository _cfgEmployeeRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgEmployeeByIdHandler(ICfgEmployeeRepository cfgEmployeeRepository, ITenantContext tenantContext)
    {
        _cfgEmployeeRepository = cfgEmployeeRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgEmployeeByIdResponse> Handle(GetCfgEmployeeByIdRequest request, CancellationToken cancellationToken)
    {
        var cfgEmployee = await _cfgEmployeeRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"CfgEmployee {request.Id} not found.");

        return new GetCfgEmployeeByIdResponse
        {
            Data = GetCfgEmployeeByIdMapper.ToDto(cfgEmployee)
        };
    }
}
