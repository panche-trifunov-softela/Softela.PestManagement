// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Locale
    {
        public int Id { get; set; }
        public string LocaleName { get; set; }
        public string LocaleCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public DateTime UtcLastChanged { get; set; }
        public string LastChangedBy { get; set; }
    }
}
