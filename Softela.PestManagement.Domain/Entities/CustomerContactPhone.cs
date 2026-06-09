namespace Softela.PestManagement.Domain.Entities;

public class CustomerContactPhone : TenantScopedEntity
{
    public int CustomerContactId { get; set; }
    public string PhoneType { get; set; }
    public string PhoneNumber { get; set; }
}
