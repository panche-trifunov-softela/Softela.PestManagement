// Diagram: WorkOrderMaterialEquipment
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderMaterialEquipment
    {
        public long Id { get; set; }
        public long WorkOrderMaterialId { get; set; }
        public int EquipmentId { get; set; }
    }
}
