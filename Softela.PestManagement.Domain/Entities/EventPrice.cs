// Diagram: EventPrice
namespace Softela.PestManagement.Domain.Entities
{
    public class EventPrice
    {
        public int Counter { get; set; }
        public int EventId { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? ProdAmount { get; set; }
        public decimal? SaleAmount { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime CreateStamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public bool GlobalIncrease { get; set; }
    }
}
