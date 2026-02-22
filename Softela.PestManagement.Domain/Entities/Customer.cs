using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Domain.Entities;

public class Customer : BaseEntity
{
    public int TenantId { get; set; }
    public string CustomerNum { get; set; }
    public string Name { get; set; }
    public CustomerType CustomerType { get; set; }
    public bool IsActive { get; set; }
    public bool SendInvoice { get; set; }
    public bool EmailInvoice { get; set; }
    public string Instructions { get; set; }
    public string PrimaryNote { get; set; }
    public string RegistrationNum { get; set; }
    public string PreferredContactMethod { get; set; }
    public string BillingAddressStreet { get; set; }
    public string BillingAddressCity { get; set; }
    public string BillingAddressState { get; set; }
    public string BillingAddressZip { get; set; }
    public bool IsDeleted { get; set; }
}
