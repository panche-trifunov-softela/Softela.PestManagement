// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class AccountPeriod : BaseEntity
    {
        public string PeriodName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
