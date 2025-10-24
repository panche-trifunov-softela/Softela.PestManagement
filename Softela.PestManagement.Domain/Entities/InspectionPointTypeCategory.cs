// Diagram: InspectionPointTypeCategory
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPointTypeCategory
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CategoryText { get; set; }
        public int IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
    }
}
