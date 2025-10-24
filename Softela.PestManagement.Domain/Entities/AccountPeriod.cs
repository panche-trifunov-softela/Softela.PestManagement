// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class AccountPeriod
    {
        public int Id { get; set; }
        public string PeriodName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsClosed { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
