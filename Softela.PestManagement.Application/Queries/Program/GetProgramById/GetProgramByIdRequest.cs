using MediatR;

namespace Softela.PestManagement.Application.Queries.Program.GetProgramById;

public sealed record GetProgramByIdRequest : IRequest<GetProgramByIdResponse>
{
    public int Id { get; init; }
}
