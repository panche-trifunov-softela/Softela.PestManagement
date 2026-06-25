using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEventById;

public sealed record GetCfgEventByIdRequest : IRequest<GetCfgEventByIdResponse>
{
    public int Id { get; init; }
}
