// Diagram: Company
namespace Softela.PestManagement.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public int LocaleId { get; set; }
        public bool IsActive { get; set; }
    }
}
