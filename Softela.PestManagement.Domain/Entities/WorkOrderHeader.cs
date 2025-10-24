// Diagram: WorkOrderHeader
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderHeader : BaseEntity
    {
        public DateTime? ScheduleDate { get; set; }
        public DateTime? PrintedDate { get; set; }
        public int? BatchId { get; set; }
        public int? ProgramId { get; set; }
        public int? ReleaseId { get; set; }
        public int? AssignedTo { get; set; }
        public Guid? CreateGroupId { get; set; }
        public int? TimeRangeId { get; set; }
        public int? Duration { get; set; }
        public int? ScheduleTime { get; set; }
        public int? Confirmed { get; set; }
        public string ModifiedBy { get; set; }
        public string PoNumber { get; set; }
    }
}
