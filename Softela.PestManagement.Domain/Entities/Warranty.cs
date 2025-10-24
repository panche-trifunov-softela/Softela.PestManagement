// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Warranty : BaseEntity
    {
        public string WarrantyName { get; set; }
        public int? WarrantyDays { get; set; }
        public bool IsActive { get; set; }
    }
}
