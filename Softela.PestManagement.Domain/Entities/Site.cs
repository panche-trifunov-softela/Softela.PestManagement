namespace Softela.PestManagement.Domain.Entities
{
    public class Site : BaseEntity
    {
        public int? AddressId { get; set; }
        public int? PrimaryContactId { get; set; }
        public int PropertyType { get; set; }
        public string Notes { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Instructions { get; set; }
        public int? TaxTypeId { get; set; }
        public int? SalespersonId { get; set; }
        public string SiteReferenceNumber { get; set; }
        public short SendCompletedWoMethod { get; set; }
        public short SendCompletedWoTo { get; set; }
        public int Facility { get; set; }
        public int FacilityType { get; set; }
        public int? SiteManagerId { get; set; }
        public string ReferenceNumber { get; set; }
        public short IsDeleted { get; set; }

        // Navigation properties
        public Address Address { get; set; }
        public Contact PrimaryContact { get; set; }
        public Contact SiteManager { get; set; }
        public ICollection<AccountSite> AccountSites { get; set; } = new List<AccountSite>();
    }
}
