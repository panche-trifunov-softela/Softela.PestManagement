// Diagram: InspectionPointType
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPointType
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string TypeText { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? IpCategoryId { get; set; }
        public bool IsMonitoring { get; set; }
        public int? AppMethodId { get; set; }
        public int? EquipmentId { get; set; }
        public int? IpLocationId { get; set; }
    }
}
