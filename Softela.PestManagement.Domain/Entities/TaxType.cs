namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Lookup table for tax types and rates
    /// </summary>
    public class TaxType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        // Tax rates
        public decimal? FederalTaxRate { get; set; }
        public decimal? StateTaxRate { get; set; }
        public decimal? LocalTaxRate { get; set; }
        public decimal TotalTaxRate { get; set; }

        // Applicability
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        // Status
        public bool IsActive { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
