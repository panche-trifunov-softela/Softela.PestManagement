// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class TargetCategory
    {
        public int Id { get; set; }
        public string TargetCategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
    }
}
