namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrder : BaseEntity
    {
        public string WorkOrderNumber { get; set; }
        public int AccountId { get; set; }
        public int SiteId { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? TechnicianId { get; set; }

        // Scheduling
        public DateTime? ScheduledDate { get; set; }
        public TimeSpan? ScheduledTime { get; set; }
        public int? Duration { get; set; } // Minutes
        public int? TimeRangeId { get; set; }

        // Status and tracking
        public int Status { get; set; } // Pending, Scheduled, InProgress, Completed, Cancelled, Skipped
        public DateTime? CompletedDate { get; set; }
        public DateTime? CancelledDate { get; set; }
        public int? CancelReasonId { get; set; }
        public string CancelReasonDescription { get; set; }
        public DateTime? SkippedDate { get; set; }
        public string SkipReason { get; set; }

        // Instructions and notes
        public string Instructions { get; set; }
        public string Notes { get; set; }
        public string TechnicianNotes { get; set; }

        // Billing
        public decimal? EstimatedAmount { get; set; }
        public decimal? CompletedAmount { get; set; }
        public int? InvoiceId { get; set; }

        // Route management
        public string RouteName { get; set; }
        public int? RouteOrder { get; set; }

        // Navigation properties
        public AccountEntity Account { get; set; }
        public SiteEntity Site { get; set; }
        public ServiceType ServiceType { get; set; }
        public Technician Technician { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<WorkOrderProduct> WorkOrderProducts { get; set; } = new List<WorkOrderProduct>();
    }
}
