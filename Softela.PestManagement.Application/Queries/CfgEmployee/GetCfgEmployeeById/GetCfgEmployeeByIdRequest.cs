using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployeeById;

public sealed record GetCfgEmployeeByIdRequest : IRequest<GetCfgEmployeeByIdResponse>
{
    public int Id { get; init; }
}
