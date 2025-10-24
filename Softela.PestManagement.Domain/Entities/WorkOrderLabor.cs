// Diagram: WorkOrderLabor
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderLabor : BaseEntity
    {
        public int WoEventId { get; set; }
        public int? BatchId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? LaborDate { get; set; }
        public decimal? LaborMinutes { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public bool Invoiced { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? FedTaxAmount { get; set; }
        public decimal? StateTaxAmount { get; set; }
        public decimal? LocalTaxAmount { get; set; }
        public string TaxTypeName { get; set; }
        public decimal? TaxFedPercent { get; set; }
        public decimal? TaxStatePercent { get; set; }
        public decimal? TaxLocalPercent { get; set; }
        public short? IsPrimary { get; set; }
        public int? TaxTypeId { get; set; }
    }
}
