namespace Softela.PestManagement.Domain.Entities;

public class Tenant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
}
