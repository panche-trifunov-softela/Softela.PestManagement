// Diagram: AccountSite
namespace Softela.PestManagement.Domain.Entities
{
    public class AccountSite
    {
        public int Counter { get; set; }
        public int AccountId { get; set; }
        public int SiteId { get; set; }
        public DateTime LastChanged { get; set; }
        public string ChangedBy { get; set; }
        public DateTime UtcTimestamp { get; set; }
    }
}
