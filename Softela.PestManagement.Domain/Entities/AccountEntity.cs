namespace Softela.PestManagement.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public int CompanyId { get; set; }
        public string AccountNum { get; set; }
        public int AccountType { get; set; }
        public int? BillingAddressId { get; set; }
        public int? BillingContactId { get; set; }
        public int BillingCenterId { get; set; }
        public int LocaleId { get; set; }

        // Communication preferences
        public bool SendInvoice { get; set; }
        public bool EmailInvoice { get; set; }
        public bool SendStatement { get; set; }
        public bool EmailStatement { get; set; }
        public bool SendRenewal { get; set; }
        public bool EmailRenewal { get; set; }
        public bool MarketingEmail { get; set; }
        public bool NotificationsMail { get; set; }

        // Notes and instructions
        public string Instructions { get; set; }
        public string PrimaryNote { get; set; }
        public string SecondaryNote { get; set; }

        // Status and hierarchy
        public short IsActive { get; set; }
        public int? MasterAccountId { get; set; }
        public int? MasterAccountSubId { get; set; }
        public string RegistrationNum { get; set; }

        // Business info
        public int? DiscountTypeId { get; set; }
        public int? AccountManagerId { get; set; }

        // Navigation properties
        public Address BillingAddress { get; set; }
        public Contact BillingContact { get; set; }
        public ICollection<AccountSite> AccountSites { get; set; } = new List<AccountSite>();
    }
}
