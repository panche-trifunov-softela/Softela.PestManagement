namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Junction table linking work orders to products/chemicals used
    /// </summary>
    public class WorkOrderProduct : BaseEntity
    {
        public int WorkOrderId { get; set; }
        public int ProductId { get; set; }

        // Application details
        public decimal QuantityUsed { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal? DilutionRatio { get; set; }
        public string ApplicationMethod { get; set; }
        public string ApplicationArea { get; set; }

        // Target
        public int? TargetPestId { get; set; }

        // Notes
        public string Notes { get; set; }

        // Navigation properties
        public WorkOrder WorkOrder { get; set; }
        public Product Product { get; set; }
        public Pest TargetPest { get; set; }
    }
}
