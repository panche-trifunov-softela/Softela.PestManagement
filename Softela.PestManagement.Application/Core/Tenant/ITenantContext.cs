namespace Softela.PestManagement.Application.Core.Tenant;

public interface ITenantContext
{
    int TenantId { get; set; }
    Guid UserId { get; set; }
}
