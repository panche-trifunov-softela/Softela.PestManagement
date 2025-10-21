namespace Softela.PestManagement.Domain.Entities
{
    /// <summary>
    /// Junction table for many-to-many relationship between Accounts and Sites
    /// </summary>
    public class AccountSite : BaseEntity
    {
        public int AccountId { get; set; }
        public int SiteId { get; set; }

        // Navigation properties
        public Account Account { get; set; }
        public Site Site { get; set; }
    }
}
