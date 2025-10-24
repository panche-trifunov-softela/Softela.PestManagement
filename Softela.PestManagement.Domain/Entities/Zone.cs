// Diagram: Zone
namespace Softela.PestManagement.Domain.Entities
{
    public class Zone : BaseEntity
    {
        public int FacilityId { get; set; }
        public string ZoneName { get; set; }
        public int IsActive { get; set; }
        public int? RoomNumber { get; set; }
        public int? ZoneTemplateTypeId { get; set; }
    }
}
