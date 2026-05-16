namespace Softela.PestManagement.Domain.Entities;

public class CustomerContact : TenantScopedEntity
{
    public int CustomerId { get; set; }
    public string ContactType { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string AlternateEmails { get; set; }
    public bool IsDeleted { get; set; }
}
