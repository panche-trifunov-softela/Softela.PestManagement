// Diagram: InspectionPoint
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPoint
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public string InspectionPointName { get; set; }
        public decimal? Number { get; set; }
        public string Barcode { get; set; }
        public int? TypeId { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public int? InventoryItemId { get; set; }
        public int? TargetTypeId { get; set; }
        public int? EventId { get; set; }
        public string CustomLocation { get; set; }
        public int Removed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
