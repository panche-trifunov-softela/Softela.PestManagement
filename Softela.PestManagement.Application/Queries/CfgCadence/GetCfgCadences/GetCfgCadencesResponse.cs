using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadences;

public sealed record GetCfgCadencesResponse
{
    public required List<CfgCadenceDto> Data { get; init; }
}
