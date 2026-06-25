using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadenceById;

public sealed record GetCfgCadenceByIdRequest : IRequest<GetCfgCadenceByIdResponse>
{
    public int Id { get; init; }
}
