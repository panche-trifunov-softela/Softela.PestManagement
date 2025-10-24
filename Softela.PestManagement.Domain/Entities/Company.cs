// Diagram: Company
namespace Softela.PestManagement.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int LocaleId { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
