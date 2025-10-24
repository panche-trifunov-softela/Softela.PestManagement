// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class CancelReason : BaseEntity
    {
        public string CancelReasonName { get; set; }
        public bool IsActive { get; set; }
    }
}
