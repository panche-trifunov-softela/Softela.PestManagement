using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadences;

public sealed record GetCfgProgramEventCadencesRequest : IRequest<GetCfgProgramEventCadencesResponse>
{
    public int CfgProgramId { get; init; }
}
