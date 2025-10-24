// Diagram: InspectionPointTypeCategory
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPointTypeCategory : BaseEntity
    {
        public int CompanyId { get; set; }
        public string CategoryText { get; set; }
        public int IsActive { get; set; }
    }
}
