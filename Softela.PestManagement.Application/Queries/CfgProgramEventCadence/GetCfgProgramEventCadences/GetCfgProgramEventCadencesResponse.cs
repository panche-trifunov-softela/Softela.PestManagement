using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadences;

public sealed record GetCfgProgramEventCadencesResponse
{
    public required List<CfgProgramEventCadenceDto> Data { get; init; }
}
