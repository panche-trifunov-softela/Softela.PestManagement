// Diagram: WorkOrderMaterialLocation
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderMaterialLocation
    {
        public int Id { get; set; }
        public int WoMaterialId { get; set; }
        public int? LocationId { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public string CreatedBy { get; set; }
        public int WoEventId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
