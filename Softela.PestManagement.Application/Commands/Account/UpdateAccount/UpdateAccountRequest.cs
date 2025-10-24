using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? BillingCenterId { get; set; }
        public int? LocaleId { get; set; }
        public bool SendInvoice { get; set; }
        public bool EmailInvoice { get; set; }
        public bool SendStatement { get; set; }
        public bool EmailStatement { get; set; }
        public bool SendRenewal { get; set; }
        public bool EmailRenewal { get; set; }
        public bool MarketingEmail { get; set; }
        public bool NotificationsMail { get; set; }
        public string? Instructions { get; set; }
        public string? PrimaryNote { get; set; }
        public string? SecondaryNote { get; set; }
        public string Name { get; set; } = string.Empty;
        public short IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? MasterAccountId { get; set; }
        public int? MasterAccountSubId { get; set; }
        public string? RegistrationNum { get; set; }
        public int? DiscountTypeId { get; set; }
        public int? AccountManagerId { get; set; }
    }
}
