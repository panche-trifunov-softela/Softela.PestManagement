// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Observation : BaseEntity
    {
        public string ObservationText { get; set; }
        public bool IsActive { get; set; }
    }
}
