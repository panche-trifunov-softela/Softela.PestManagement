namespace Softela.PestManagement.Domain.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool IsActive { get; set; }
}
