using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.Program.GetProgramById;

public sealed record GetProgramByIdResponse
{
    public ProgramDto Data { get; init; }
}
