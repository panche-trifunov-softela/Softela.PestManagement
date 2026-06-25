using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadenceById;

public sealed record GetCfgProgramEventCadenceByIdRequest : IRequest<GetCfgProgramEventCadenceByIdResponse>
{
    public int Id { get; init; }
}
