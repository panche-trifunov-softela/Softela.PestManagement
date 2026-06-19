using MediatR;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Estimate.UpdateEstimate;

public sealed record UpdateEstimateRequest : IRequest<bool>
{
    public int Id { get; init; }
    public int ServiceAddressId { get; init; }
    public int CfgEstimateId { get; init; }
    public LeadStatus Status { get; init; }
    public string? ServiceInterest { get; init; }
    public int AssignedSalesRep { get; init; }
    public LeadSource Source { get; init; }
}
