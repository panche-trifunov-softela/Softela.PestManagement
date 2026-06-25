using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgProgram.UpdateCfgProgram;

public sealed record UpdateCfgProgramRequest : IRequest<bool>
{
    public int Id { get; init; }
    public required string Name { get; init; }
}
