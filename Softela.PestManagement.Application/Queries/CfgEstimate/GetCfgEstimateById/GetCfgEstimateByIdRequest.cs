using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimateById;

public sealed record GetCfgEstimateByIdRequest : IRequest<GetCfgEstimateByIdResponse>
{
    public int Id { get; init; }
}
