using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEventById;

public sealed record GetCfgEventByIdResponse
{
    public required CfgEventDto Data { get; init; }
}
