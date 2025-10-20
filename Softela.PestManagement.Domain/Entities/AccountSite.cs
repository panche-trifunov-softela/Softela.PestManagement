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
        public AccountEntity Account { get; set; }
        public SiteEntity Site { get; set; }
    }
}
