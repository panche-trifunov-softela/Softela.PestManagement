// Diagram: Program
namespace Softela.PestManagement.Domain.Entities
{
    public class Program
    {
        public int Id { get; set; }
        public int ProgramTypeId { get; set; }
        public string ProgramName { get; set; }
        public int? EstimateId { get; set; }
        public int AccountId { get; set; }
        public int SiteId { get; set; }
        public short? ProgramStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public int? CancelReasonId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
