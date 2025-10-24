// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Locale : BaseEntity
    {
        public string LocaleName { get; set; }
        public string LocaleCode { get; set; }
        public bool IsActive { get; set; }
    }
}
