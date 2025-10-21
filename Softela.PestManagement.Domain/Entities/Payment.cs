namespace Softela.PestManagement.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentNumber { get; set; }
        public int AccountId { get; set; }
        public int? InvoiceId { get; set; }

        // Payment details
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        // Payment method
        public int PaymentMethodId { get; set; } // Cash, Check, Credit Card, ACH, etc.
        public string PaymentMethodName { get; set; }

        // Reference info
        public string ReferenceNumber { get; set; } // Check number, transaction ID, etc.
        public string ConfirmationNumber { get; set; }

        // Credit card info (if applicable)
        public string CardType { get; set; }
        public string CardLastFour { get; set; }

        // Status
        public int Status { get; set; } // Pending, Completed, Failed, Refunded
        public bool IsProcessed { get; set; }

        // Notes
        public string Notes { get; set; }

        // Navigation properties
        public Account Account { get; set; }
        public Invoice Invoice { get; set; }
    }
}
