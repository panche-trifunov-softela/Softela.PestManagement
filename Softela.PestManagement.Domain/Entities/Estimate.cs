using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Domain.Entities;

public class Estimate : BaseEntity
{
    public string Name { get; set; }
    public LeadStatus Status { get; set; }
    public int ServiceAddressId { get; set; }
    public string ServiceInterest { get; set; }
    public int AssignedSalesRep { get; set; }
    public LeadSource Source { get; set; }
}
