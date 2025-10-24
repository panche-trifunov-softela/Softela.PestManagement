// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class TimeRange : BaseEntity
    {
        public string TimeRangeName { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
