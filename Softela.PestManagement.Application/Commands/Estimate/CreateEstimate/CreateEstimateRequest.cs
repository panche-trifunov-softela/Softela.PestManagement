using MediatR;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Estimate.CreateEstimate;

public sealed record CreateEstimateRequest : IRequest<int>
{
    public int ServiceAddressId { get; init; }
    public string Name { get; init; }
    public LeadStatus Status { get; init; }
    public string? ServiceInterest { get; init; }
    public int AssignedSalesRep { get; init; }
    public LeadSource Source { get; init; }
}
