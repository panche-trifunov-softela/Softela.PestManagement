// Diagram: Facility
namespace Softela.PestManagement.Domain.Entities
{
    public class Facility : BaseEntity
    {
        public int SiteId { get; set; }
        public string FacilityName { get; set; }
        public int IsActive { get; set; }
        public int? FacilityTemplateTypeId { get; set; }
    }
}
