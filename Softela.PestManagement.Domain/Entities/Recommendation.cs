// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Recommendation : BaseEntity
    {
        public string RecommendationText { get; set; }
        public bool IsActive { get; set; }
    }
}
