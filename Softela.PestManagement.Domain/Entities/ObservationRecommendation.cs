// Diagram: ObservationRecommendation
namespace Softela.PestManagement.Domain.Entities
{
    public class ObservationRecommendation
    {
        public int ObservationId { get; set; }
        public int RecommendationId { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public string CreatedBy { get; set; }
    }
}
