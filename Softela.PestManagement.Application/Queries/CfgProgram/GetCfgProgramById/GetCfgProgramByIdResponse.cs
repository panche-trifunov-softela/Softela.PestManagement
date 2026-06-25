using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgProgramById;

public sealed record GetCfgProgramByIdResponse
{
    public required CfgProgramDto Data { get; init; }
}
