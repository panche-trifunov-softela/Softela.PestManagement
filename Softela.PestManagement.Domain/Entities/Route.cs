namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Represents a service route for technicians
    /// </summary>
    public class Route : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        // Route details
        public int? DefaultTechnicianId { get; set; }
        public int? BranchId { get; set; }
        public string Territory { get; set; }

        // Schedule
        public string DaysOfWeek { get; set; } // JSON or comma-separated (Mon,Wed,Fri)
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        // Status
        public bool IsActive { get; set; }
        public string Color { get; set; } // For calendar/map display

        // Navigation properties
        public Technician DefaultTechnician { get; set; }
    }
}
