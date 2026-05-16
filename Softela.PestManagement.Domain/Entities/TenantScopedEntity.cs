namespace Softela.PestManagement.Domain.Entities
{
    public class TenantScopedEntity : BaseEntity
    {
        public int TenantId { get; set; }
    }
}
