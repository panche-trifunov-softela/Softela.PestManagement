namespace Softela.PestManagement.Application.Core.Tenant;

public interface ITenantContext
{
    int TenantId { get; }
    Guid UserId { get; }
}
