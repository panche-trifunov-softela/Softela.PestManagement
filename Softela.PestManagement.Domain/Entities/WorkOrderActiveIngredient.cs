// Diagram: WorkOrderActiveIngredient
namespace Softela.PestManagement.Domain.Entities
{
    public class WorkOrderActiveIngredient
    {
        public int Id { get; set; }
        public int WoMaterialId { get; set; }
        public string ActiveIngredient { get; set; }
        public decimal? ActivePct { get; set; }
        public bool IsDeleted { get; set; }
    }
}
