using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEvents;

public sealed record GetCfgEventsResponse
{
    public required List<CfgEventDto> Data { get; init; }
}
