// Diagram: Facility
namespace Softela.PestManagement.Domain.Entities
{
    public class Facility
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string FacilityName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public int IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? FacilityTemplateTypeId { get; set; }
    }
}
