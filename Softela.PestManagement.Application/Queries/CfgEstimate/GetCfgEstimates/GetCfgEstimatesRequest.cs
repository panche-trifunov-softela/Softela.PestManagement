using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimates;

public sealed record GetCfgEstimatesRequest : IRequest<GetCfgEstimatesResponse>;
