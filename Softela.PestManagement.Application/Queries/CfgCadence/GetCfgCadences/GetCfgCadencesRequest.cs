using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadences;

public sealed record GetCfgCadencesRequest : IRequest<GetCfgCadencesResponse>;
