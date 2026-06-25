using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgProgram.CreateCfgProgram;

public sealed record CreateCfgProgramRequest : IRequest<int>
{
    public required string Name { get; init; }
}
