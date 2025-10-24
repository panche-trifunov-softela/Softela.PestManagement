// Diagram: ZoneTemplateType
namespace Softela.PestManagement.Domain.Entities
{
    public class ZoneTemplateType : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public int? IpCategoryId { get; set; }
        public int? LocationTypeId { get; set; }
    }
}
