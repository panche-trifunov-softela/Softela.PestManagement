namespace Softela.PestManagement.Domain.Entities
{
    public class ServiceType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int? ServiceCategoryId { get; set; }

        // Pricing
        public decimal? DefaultPrice { get; set; }
        public int? DefaultDuration { get; set; } // Minutes

        // Settings
        public bool IsActive { get; set; }
        public bool RequiresLicense { get; set; }
        public string LicenseType { get; set; }

        // Navigation properties
        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
