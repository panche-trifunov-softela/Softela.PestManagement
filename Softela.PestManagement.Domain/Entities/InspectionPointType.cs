// Diagram: InspectionPointType
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPointType : BaseEntity
    {
        public int CompanyId { get; set; }
        public string TypeText { get; set; }
        public bool IsActive { get; set; }
        public int? IpCategoryId { get; set; }
        public bool IsMonitoring { get; set; }
        public int? AppMethodId { get; set; }
        public int? EquipmentId { get; set; }
        public int? IpLocationId { get; set; }
    }
}
