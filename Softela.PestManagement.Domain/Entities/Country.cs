namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for countries
    /// </summary>
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; } // ISO 3166-1 alpha-2 code (US, CA, MX, etc.)
        public string Code3 { get; set; } // ISO 3166-1 alpha-3 code (USA, CAN, MEX, etc.)
        public string NumericCode { get; set; } // ISO 3166-1 numeric code
        public string PhoneCode { get; set; } // International dialing code (+1, +44, etc.)
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}
