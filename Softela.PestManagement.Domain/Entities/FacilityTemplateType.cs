// Diagram: FacilityTemplateType
namespace Softela.PestManagement.Domain.Entities
{
    public class FacilityTemplateType : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public int? IpTypeId { get; set; }
    }
}
