// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class DiscountType : BaseEntity
    {
        public string DiscountTypeName { get; set; }
        public decimal? DiscountPercent { get; set; }
        public bool IsActive { get; set; }
    }
}
