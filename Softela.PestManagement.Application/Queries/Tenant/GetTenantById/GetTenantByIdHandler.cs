using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Tenant.GetTenantById;

public class GetTenantByIdHandler : IRequestHandler<GetTenantByIdRequest, GetTenantByIdResponse>
{
    private readonly ITenantRepository _tenantRepository;

    public GetTenantByIdHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<GetTenantByIdResponse> Handle(GetTenantByIdRequest request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.Id);
        return new GetTenantByIdResponse { Data = tenant };
    }
}
