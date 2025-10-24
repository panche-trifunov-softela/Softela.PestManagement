// Diagram: Estimate
namespace Softela.PestManagement.Domain.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public int EstimateTypeId { get; set; }
        public string EstimateName { get; set; }
        public int AccountId { get; set; }
        public int SiteId { get; set; }
        public DateTime? EstimateDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? RejectedReason { get; set; }
        public DateTime? SoldDate { get; set; }
        public short? EstimateStatus { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public int? ServiceCenter { get; set; }
        public int? SourceId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
