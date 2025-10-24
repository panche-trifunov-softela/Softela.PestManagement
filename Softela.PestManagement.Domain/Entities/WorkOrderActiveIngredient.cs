// Diagram: WorkOrderActiveIngredient
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderActiveIngredient : BaseEntity
    {
        public int WoMaterialId { get; set; }
        public string ActiveIngredient { get; set; }
        public decimal? ActivePct { get; set; }
    }
}
