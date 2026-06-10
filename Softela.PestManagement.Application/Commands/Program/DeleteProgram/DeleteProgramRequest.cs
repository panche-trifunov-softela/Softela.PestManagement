using MediatR;

namespace Softela.PestManagement.Application.Commands.Program.DeleteProgram;

public sealed record DeleteProgramRequest : IRequest<bool>
{
    public int Id { get; init; }
}
