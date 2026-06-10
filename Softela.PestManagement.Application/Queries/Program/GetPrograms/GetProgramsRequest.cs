using MediatR;

namespace Softela.PestManagement.Application.Queries.Program.GetPrograms;

public sealed record GetProgramsRequest : IRequest<GetProgramsResponse>
{
    public int EstimateId { get; init; }
}
