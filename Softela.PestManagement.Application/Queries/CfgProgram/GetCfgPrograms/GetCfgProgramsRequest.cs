using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgProgram.GetCfgPrograms;

public sealed record GetCfgProgramsRequest : IRequest<GetCfgProgramsResponse>;
