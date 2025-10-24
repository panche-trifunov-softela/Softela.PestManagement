// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
