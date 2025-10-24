// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class RejectedReason : BaseEntity
    {
        public string RejectedReasonName { get; set; }
        public bool IsActive { get; set; }
    }
}
