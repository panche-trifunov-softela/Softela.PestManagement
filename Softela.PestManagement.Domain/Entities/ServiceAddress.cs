namespace Softela.PestManagement.Domain.Entities;

public class ServiceAddress : TenantScopedEntity
{
    public int CustomerId { get; set; }
    public string ServiceAddressName { get; set; }
    public string ServiceAddressType { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string ContactName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public bool IsActive { get; set; }
}
