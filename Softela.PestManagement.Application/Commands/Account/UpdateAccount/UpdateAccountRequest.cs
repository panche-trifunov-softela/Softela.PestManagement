using MediatR;

namespace Softela.PestManagement.Application.Commands.Account.UpdateAccount
{
    public sealed record UpdateAccountRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string AccountNum { get; set; } = string.Empty;
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
        public string? Instructions { get; set; }
        public string? PrimaryNote { get; set; }
        public string? SecondaryNote { get; set; }

        // Status and hierarchy
        public string? Name { get; set; }
        public short IsActive { get; set; }
        public short IsDeleted { get; set; }
        public int? MasterAccountId { get; set; }
        public int? MasterAccountSubId { get; set; }
        public string? RegistrationNum { get; set; }

        // Business info
        public int? DiscountTypeId { get; set; }
        public int? AccountManagerId { get; set; }
    }
}
