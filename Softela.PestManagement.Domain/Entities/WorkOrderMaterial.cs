// Diagram: WorkOrderMaterial
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderMaterial : BaseEntity
    {
        public int WoEventId { get; set; }
        public int? BatchId { get; set; }
        public DateTime? MaterialDate { get; set; }
        public int? ItemId { get; set; }
        public string ItemNum { get; set; }
        public string ItemDescription { get; set; }
        public decimal? PricePerUnit { get; set; }
        public decimal? MaterialQuantity { get; set; }
        public bool Invoiced { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public string TaxTypeName { get; set; }
        public decimal? TaxFedPercent { get; set; }
        public decimal? TaxStatePercent { get; set; }
        public decimal? TaxLocalPercent { get; set; }
        public decimal? FedTaxAmount { get; set; }
        public decimal? StateTaxAmount { get; set; }
        public decimal? LocalTaxAmount { get; set; }
        public int? TaxTypeId { get; set; }
        public int? InspectionPointHistoryId { get; set; }
        public int? EquipmentId { get; set; }
        public int? LocationId { get; set; }
        public string CustomLocation { get; set; }
        public string UsageUom { get; set; }
        public string ActiveIngredient { get; set; }
        public string TreatmentNotes { get; set; }
        public string ApplicationRate { get; set; }
    }
}
