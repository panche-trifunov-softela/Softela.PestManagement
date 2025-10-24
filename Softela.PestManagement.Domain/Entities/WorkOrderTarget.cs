// Diagram: WorkOrderTarget
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderTarget : BaseEntity
    {
        public int WoEventId { get; set; }
        public int TargetTypeId { get; set; }
        public int? NumberFound { get; set; }
        public int? InspectionPointHistoryId { get; set; }
        public int? WoMaterialId { get; set; }
        public int? TargetCategoryId { get; set; }
        public bool IsPrimary { get; set; }
        public int? ActivityLevel { get; set; }
        public int? WarrantyId { get; set; }
    }
}
