using Softela.PestManagement.Application.Core.Tenant;

namespace Softela.PestManagement.API.Middleware;

public class TenantContext : ITenantContext
{
    public int TenantId { get; set; }
    public Guid UserId { get; set; }
}
