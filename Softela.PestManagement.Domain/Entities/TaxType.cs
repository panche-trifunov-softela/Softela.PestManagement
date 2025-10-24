// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class TaxType : BaseEntity
    {
        public string TaxTypeName { get; set; }
        public decimal? FederalPercent { get; set; }
        public decimal? StatePercent { get; set; }
        public decimal? LocalPercent { get; set; }
        public bool IsActive { get; set; }
    }
}
