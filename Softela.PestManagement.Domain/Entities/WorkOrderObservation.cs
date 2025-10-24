// Diagram: WorkOrderObservation
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderObservation : BaseEntity
    {
        public int WoEventId { get; set; }
        public int? ObservationId { get; set; }
        public string CustomObservationText { get; set; }
        public int? RecommendationId { get; set; }
        public string CustomRecommendationText { get; set; }
        public short? EntityResponsible { get; set; }
        public string CustomLocationText { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int? ZoneId { get; set; }
        public int? InspectionPointHistoryId { get; set; }
        public string ImageName { get; set; }
    }
}
