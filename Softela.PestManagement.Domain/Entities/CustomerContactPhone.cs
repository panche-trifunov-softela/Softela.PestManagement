namespace Softela.PestManagement.Domain.Entities;

public class CustomerContactPhone
{
    public int Id { get; set; }
    public int TenantId { get; set; }
    public int CustomerContactId { get; set; }
    public string PhoneType { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
