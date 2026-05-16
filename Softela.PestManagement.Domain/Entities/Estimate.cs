using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Domain.Entities;

public class Estimate : TenantScopedEntity
{
    public string Name { get; set; }
    public LeadStatus Status { get; set; }
    public int ServiceAddressId { get; set; }
    public string ServiceInterest { get; set; }
    public int AssignedSalesRep { get; set; }
    public LeadSource Source { get; set; }
    public bool IsDeleted { get; set; }
}
