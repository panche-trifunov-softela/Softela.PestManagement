using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgPrograms;

public sealed record GetCfgProgramsResponse
{
    public required List<CfgProgramDto> Data { get; init; }
}
