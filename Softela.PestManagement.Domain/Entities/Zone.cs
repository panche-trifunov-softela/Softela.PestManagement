// Diagram: Zone
namespace Softela.PestManagement.Domain.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public string ZoneName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public int IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? RoomNumber { get; set; }
        public int? ZoneTemplateTypeId { get; set; }
    }
}
