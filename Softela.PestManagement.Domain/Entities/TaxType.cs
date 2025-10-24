// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class TaxType
    {
        public int Id { get; set; }
        public string TaxTypeName { get; set; }
        public decimal? FederalPercent { get; set; }
        public decimal? StatePercent { get; set; }
        public decimal? LocalPercent { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
    }
}
