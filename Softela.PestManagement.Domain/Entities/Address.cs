// Diagram: Address
namespace Softela.PestManagement.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string StreetNumber { get; set; }
        public string PreDirection { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string PostDirection { get; set; }
        public string SecondaryAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PostalCodeEx { get; set; }
        public int? CountryId { get; set; }
        public int? LocaleId { get; set; }
        public int? SuffixId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
