// Diagram: Batch
namespace Softela.PestManagement.Domain.Entities
{
    public class Batch : BaseEntity
    {
        public int OwnerId { get; set; }
        public int CompanyId { get; set; }
        public byte BatchType { get; set; }
        public string Descr { get; set; }
        public DateTime UtcCreateDate { get; set; }
        public DateTime? UtcClosedDate { get; set; }
        public string ClosedBy { get; set; }
        public DateTime UtcLastUpdated { get; set; }
        public int? AcctPeriodId { get; set; }
    }
}
