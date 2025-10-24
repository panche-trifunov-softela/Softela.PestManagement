// Diagram: WorkOrderHeader
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderHeader
    {
        public int Id { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? PrintedDate { get; set; }
        public int? BatchId { get; set; }
        public int? ProgramId { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public int? ReleaseId { get; set; }
        public int? AssignedTo { get; set; }
        public Guid? CreateGroupId { get; set; }
        public int? TimeRangeId { get; set; }
        public int? Duration { get; set; }
        public int? ScheduleTime { get; set; }
        public int? Confirmed { get; set; }
        public string ModifiedBy { get; set; }
        public string PoNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
