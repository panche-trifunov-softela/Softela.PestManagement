using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Dtos;

public sealed record EstimateDto
{
    public int Id { get; init; }
    public int ServiceAddressId { get; init; }
    public int CfgEstimateId { get; init; }
    public LeadStatus Status { get; init; }
    public string? ServiceInterest { get; init; }
    public int AssignedSalesRep { get; init; }
    public LeadSource Source { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
