namespace Softela.PestManagement.Domain.Entities
{
    public class Technician : BaseEntity
    {
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        // Contact info
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        // Employment
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool IsActive { get; set; }

        // Licensing and certifications
        public string LicenseNumber { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public string CertificationNumbers { get; set; } // Comma-separated or JSON
        public string Certifications { get; set; }

        // Work info
        public int? DefaultRouteId { get; set; }
        public int? BranchId { get; set; }
        public string Territory { get; set; }

        // Settings
        public bool CanSchedule { get; set; }
        public bool CanInvoice { get; set; }
        public int? UserId { get; set; } // Link to User table

        // Navigation properties
        public User User { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
