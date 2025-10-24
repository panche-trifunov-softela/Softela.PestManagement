// Diagram: WorkOrderEvent
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderEvent : BaseEntity
    {
        public int BaseEventId { get; set; }
        public int HeaderId { get; set; }
        public string EventName { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? CompletedAmount { get; set; }
        public decimal? SaleAmount { get; set; }
        public decimal? ProdAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string TaxTypeName { get; set; }
        public decimal? FederalTaxAmount { get; set; }
        public decimal? StateTaxAmount { get; set; }
        public decimal? LocalTaxAmount { get; set; }
        public string JobInstructions { get; set; }
        public int? BatchId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string NoteToCustomer { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public DateTime? OriginalDate { get; set; }
        public string GeneratedBy { get; set; }
        public DateTime? PrintDate { get; set; }
        public Guid? GeneratedBatch { get; set; }
        public DateTime? SkippedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public decimal? TaxFedPercent { get; set; }
        public decimal? TaxStatePercent { get; set; }
        public decimal? TaxLocalPercent { get; set; }
        public Guid? CreateGroupId { get; set; }
        public int? Duration { get; set; }
        public int? TaxTypeId { get; set; }
        public int? ServiceCenterId { get; set; }
        public string SkipReason { get; set; }
        public DateTime? CompletedEmailDate { get; set; }
        public DateTime? CompletedPrintDate { get; set; }
        public string TechComments { get; set; }
        public string PurchaseOrder { get; set; }
        public int? CancelReasonId { get; set; }
        public string CancelReasonDesc { get; set; }
    }
}
