using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadenceById;

public sealed record GetCfgCadenceByIdResponse
{
    public required CfgCadenceDto Data { get; init; }
}
