using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgProgramById;

public sealed record GetCfgProgramByIdRequest : IRequest<GetCfgProgramByIdResponse>
{
    public int Id { get; init; }
}
