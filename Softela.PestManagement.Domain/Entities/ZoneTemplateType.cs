// Diagram: ZoneTemplateType
namespace Softela.PestManagement.Domain.Entities
{
    public class ZoneTemplateType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? IpCategoryId { get; set; }
        public int? LocationTypeId { get; set; }
    }
}
