using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Program.GetPrograms;

public class GetProgramsHandler : IRequestHandler<GetProgramsRequest, GetProgramsResponse>
{
    private readonly IProgramRepository _programRepository;
    private readonly ITenantContext _tenantContext;

    public GetProgramsHandler(IProgramRepository programRepository, ITenantContext tenantContext)
    {
        _programRepository = programRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetProgramsResponse> Handle(GetProgramsRequest request, CancellationToken cancellationToken)
    {
        var programs = await _programRepository.GetByEstimateIdAsync(request.EstimateId, _tenantContext.TenantId);

        return new GetProgramsResponse
        {
            Data = programs.Select(GetProgramsMapper.ToDto).ToList()
        };
    }
}
