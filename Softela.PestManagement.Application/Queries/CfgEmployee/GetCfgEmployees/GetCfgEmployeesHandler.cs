using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployees;

public class GetCfgEmployeesHandler : IRequestHandler<GetCfgEmployeesRequest, GetCfgEmployeesResponse>
{
    private readonly ICfgEmployeeRepository _cfgEmployeeRepository;
    private readonly ITenantContext _tenantContext;

    public GetCfgEmployeesHandler(ICfgEmployeeRepository cfgEmployeeRepository, ITenantContext tenantContext)
    {
        _cfgEmployeeRepository = cfgEmployeeRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCfgEmployeesResponse> Handle(GetCfgEmployeesRequest request, CancellationToken cancellationToken)
    {
        var cfgEmployees = await _cfgEmployeeRepository.GetByTenantIdAsync(_tenantContext.TenantId);

        return new GetCfgEmployeesResponse
        {
            Data = cfgEmployees.Select(GetCfgEmployeesMapper.ToDto).ToList()
        };
    }
}
