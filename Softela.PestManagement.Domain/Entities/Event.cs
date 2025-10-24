// Diagram: Event
namespace Softela.PestManagement.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int EventTypeId { get; set; }
        public int ProgramId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public short Status { get; set; }
        public short? PatternInterval { get; set; }
        public int? IntervalValue { get; set; }
        public short? SkipMonths { get; set; }
        public int? AssignedTo { get; set; }
        public string PermInstructions { get; set; }
        public string OneTimeInstructions { get; set; }
        public DateTime? CancelDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public short? SkipDays { get; set; }
        public int? TaxTypeId { get; set; }
        public DateTime? BaseDate { get; set; }
        public int? ScheduledTime { get; set; }
        public int? TimeOptionId { get; set; }
        public int? SalesPersonId { get; set; }
        public int? CancelReasonId { get; set; }
        public int? Duration { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? StopAfter { get; set; }
        public short? SpecificDay { get; set; }
        public int? WarrantyId { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public string CustomerInvoiceNote { get; set; }
        public string CancelledBy { get; set; }
    }
}
