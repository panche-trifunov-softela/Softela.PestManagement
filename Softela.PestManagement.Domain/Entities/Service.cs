namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Represents a service agreement/program for an account
    /// </summary>
    public class Service : BaseEntity
    {
        public int AccountId { get; set; }
        public int SiteId { get; set; }
        public int ServiceTypeId { get; set; }

        // Contract/Program info
        public string ProgramName { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? PendingCancelDate { get; set; }

        // Frequency and scheduling
        public int? FrequencyTypeId { get; set; } // Monthly, Quarterly, Annual, etc.
        public int? FrequencyValue { get; set; }
        public string SchedulePattern { get; set; }

        // Pricing
        public decimal? Price { get; set; }
        public int? BillingCycleId { get; set; }

        // Instructions and notes
        public string Instructions { get; set; }
        public string Notes { get; set; }

        // Purchase order
        public string PurchaseOrder { get; set; }
        public DateTime? POExpirationDate { get; set; }

        // Status
        public bool IsActive { get; set; }

        // Navigation properties
        public AccountEntity Account { get; set; }
        public SiteEntity Site { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
