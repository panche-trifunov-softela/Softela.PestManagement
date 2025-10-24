// Diagram: WorkOrderMaterialLocation
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderMaterialLocation : BaseEntity
    {
        public int WoMaterialId { get; set; }
        public int? LocationId { get; set; }
        public int WoEventId { get; set; }
    }
}
