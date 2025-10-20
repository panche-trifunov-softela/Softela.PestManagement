namespace Softela.PestManagement.Domain.Entities
{
    public class InvoiceLineItem : BaseEntity
    {
        public int InvoiceId { get; set; }
        public int LineNumber { get; set; }

        // Item details
        public string Description { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ProductId { get; set; }
        public int? WorkOrderId { get; set; }

        // Quantities and pricing
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }

        // Tax
        public bool IsTaxable { get; set; }
        public decimal? TaxAmount { get; set; }

        // Navigation properties
        public Invoice Invoice { get; set; }
        public ServiceType ServiceType { get; set; }
        public Product Product { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
