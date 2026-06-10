using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.Program.GetPrograms;

public sealed record GetProgramsResponse
{
    public required List<ProgramDto> Data { get; init; }
}
