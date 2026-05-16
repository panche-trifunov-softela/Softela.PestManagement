using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Estimate.GetEstimates;

public class GetEstimatesHandler : IRequestHandler<GetEstimatesRequest, GetEstimatesResponse>
{
    private readonly IEstimateRepository _estimateRepository;
    private readonly ITenantContext _tenantContext;

    public GetEstimatesHandler(
        IEstimateRepository estimateRepository,
        ITenantContext tenantContext)
    {
        _estimateRepository = estimateRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetEstimatesResponse> Handle(GetEstimatesRequest request, CancellationToken cancellationToken)
    {
        var estimates = await _estimateRepository.GetByServiceAddressIdAsync(request.ServiceAddressId, _tenantContext.TenantId);

        var dtos = estimates.Select(GetEstimatesMapper.ToDto).ToList();

        return new GetEstimatesResponse { Data = dtos };
    }
}
