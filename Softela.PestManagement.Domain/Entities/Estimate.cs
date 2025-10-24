// Diagram: Estimate
namespace Softela.PestManagement.Domain.Entities
{
    public class Estimate : BaseEntity
    {
        public int EstimateTypeId { get; set; }
        public string EstimateName { get; set; }
        public int AccountId { get; set; }
        public int SiteId { get; set; }
        public DateTime? EstimateDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? RejectedReason { get; set; }
        public DateTime? SoldDate { get; set; }
        public short? EstimateStatus { get; set; }
        public int? ServiceCenter { get; set; }
        public int? SourceId { get; set; }
    }
}
