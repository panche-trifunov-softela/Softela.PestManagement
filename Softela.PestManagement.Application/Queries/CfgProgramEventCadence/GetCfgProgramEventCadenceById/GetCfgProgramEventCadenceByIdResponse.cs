using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadenceById;

public sealed record GetCfgProgramEventCadenceByIdResponse
{
    public required CfgProgramEventCadenceDto Data { get; init; }
}
