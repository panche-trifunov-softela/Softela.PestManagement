// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
    }
}
