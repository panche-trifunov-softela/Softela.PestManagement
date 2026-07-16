using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEmployee.DeleteCfgEmployee;

public sealed record DeleteCfgEmployeeRequest : IRequest<bool>
{
    public int Id { get; init; }
}
