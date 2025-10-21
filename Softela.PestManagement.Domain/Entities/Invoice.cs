namespace Softela.PestManagement.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public int AccountId { get; set; }
        public int? SiteId { get; set; }

        // Dates
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }

        // Amounts
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceDue { get; set; }

        // Tax details
        public int? TaxTypeId { get; set; }
        public decimal? FederalTaxAmount { get; set; }
        public decimal? StateTaxAmount { get; set; }
        public decimal? LocalTaxAmount { get; set; }

        // Status
        public int Status { get; set; } // Draft, Sent, Paid, PartiallyPaid, Overdue, Cancelled
        public bool IsPaid { get; set; }

        // Notes and references
        public string Notes { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Terms { get; set; }

        // Navigation properties
        public Account Account { get; set; }
        public Site Site { get; set; }
        public ICollection<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
