using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEvents;

public sealed record GetCfgEventsRequest : IRequest<GetCfgEventsResponse>;
