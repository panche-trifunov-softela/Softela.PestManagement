using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Domain.Entities
{
    public class OpsProgram : TenantScopedEntity
    {
        public int CfgProgramId { get; set; }
        public bool IsActive { get; set; }
        public int OpsEstimateId { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? RenewalDate { get; set; }
        public DateTimeOffset? CanceledDate { get; set; }
        public DateTimeOffset? PendingCancelDate { get; set; }
        public ProgramFrequency Frequency { get; set; }
    }
}
