// Diagram: Site
namespace Softela.PestManagement.Domain.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }
        public int? PrimaryContactId { get; set; }
        public int PropertyType { get; set; }
        public string Notes { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Instructions { get; set; }
        public int? TaxTypeId { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public int? SalesPersonId { get; set; }
        public string SiteReferenceNumber { get; set; }
        public short? SendCompletedWoMethod { get; set; }
        public short? SendCompletedWoTo { get; set; }
        public int? Facility { get; set; }
        public int? FacilityType { get; set; }
        public int? SiteManagerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
