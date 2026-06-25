using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgProgram.DeleteCfgProgram;

public sealed record DeleteCfgProgramRequest : IRequest<bool>
{
    public int Id { get; init; }
}
