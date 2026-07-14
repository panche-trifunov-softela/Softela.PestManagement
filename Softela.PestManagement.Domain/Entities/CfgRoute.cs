namespace Softela.PestManagement.Domain.Entities;

public class CfgRoute : TenantScopedEntity
{
    public int CfgEmployeeId { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; }

    public string? Note { get; set; }
}
