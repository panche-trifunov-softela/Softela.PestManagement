// Diagram: InspectionPoint
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPoint : BaseEntity
    {
        public int ZoneId { get; set; }
        public string InspectionPointName { get; set; }
        public decimal? Number { get; set; }
        public string Barcode { get; set; }
        public int? TypeId { get; set; }
        public string Notes { get; set; }
        public int? InventoryItemId { get; set; }
        public int? TargetTypeId { get; set; }
        public int? EventId { get; set; }
        public string CustomLocation { get; set; }
        public int Removed { get; set; }
    }
}
