using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Program.GetProgramById;

public class GetProgramByIdHandler : IRequestHandler<GetProgramByIdRequest, GetProgramByIdResponse>
{
    private readonly IProgramRepository _programRepository;
    private readonly ITenantContext _tenantContext;

    public GetProgramByIdHandler(IProgramRepository programRepository, ITenantContext tenantContext)
    {
        _programRepository = programRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetProgramByIdResponse> Handle(GetProgramByIdRequest request, CancellationToken cancellationToken)
    {
        var program = await _programRepository.GetByIdAsync(request.Id, _tenantContext.TenantId)
            ?? throw new KeyNotFoundException($"Program {request.Id} not found.");

        return new GetProgramByIdResponse
        {
            Data = GetProgramByIdMapper.ToDto(program)
        };
    }
}
