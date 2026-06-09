using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Domain.Entities
{
    public class Program : TenantScopedEntity
    {
        public required string Name { get; set; }
        public bool Status { get; set; }
        public int EstimateId { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? RenewalDate { get; set; }
        public DateTimeOffset? CanceledDate { get; set; }
        public DateTimeOffset? PendingCancelDate { get; set; }
        public ProgramFrequency Frequency { get; set; }
    }
}
