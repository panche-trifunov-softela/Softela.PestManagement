using Softela.PestManagement.Application.Commands.Account.CreateAccount;
using Softela.PestManagement.Application.Commands.Account.UpdateAccount;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Commands.Account.Shared
{
    public static class AccountMapper
    {
        /// <summary>
        /// Map CreateAccountRequest to Account entity
        /// </summary>
        public static AccountEntity ToEntity(this CreateAccountRequest request, string? auditUser = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var user = auditUser ?? "SYSTEM";

            return new AccountEntity
            {
                Id = 0,
                CompanyId = request.CompanyId,
                AccountNum = request.AccountNum,
                AccountType = request.AccountType,
                BillingAddressId = request.BillingAddressId,
                BillingContactId = request.BillingContactId,
                BillingCenterId = request.BillingCenterId,
                LocaleId = request.LocaleId,
                SendInvoice = request.SendInvoice,
                EmailInvoice = request.EmailInvoice,
                SendStatement = request.SendStatement,
                EmailStatement = request.EmailStatement,
                SendRenewal = request.SendRenewal,
                EmailRenewal = request.EmailRenewal,
                MarketingEmail = request.MarketingEmail,
                NotificationsMail = request.NotificationsMail,
                Instructions = request.Instructions ?? string.Empty,
                PrimaryNote = request.PrimaryNote ?? string.Empty,
                SecondaryNote = request.SecondaryNote ?? string.Empty,
                Name = request.Name,
                IsActive = request.IsActive,
                IsDeleted = false,
                MasterAccountId = request.MasterAccountId,
                MasterAccountSubId = request.MasterAccountSubId,
                RegistrationNum = request.RegistrationNum ?? string.Empty,
                DiscountTypeId = request.DiscountTypeId,
                AccountManagerId = request.AccountManagerId,
                UtcTimestamp = DateTime.UtcNow,
                CreatedBy = user,
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = user
            };
        }

        /// <summary>
        /// Map UpdateAccountRequest to Account entity
        /// </summary>
        public static AccountEntity ToEntity(this UpdateAccountRequest request, string? auditUser = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var user = auditUser ?? "SYSTEM";

            return new AccountEntity
            {
                Id = request.Id,
                CompanyId = request.CompanyId,
                AccountNum = request.AccountNum,
                AccountType = request.AccountType,
                BillingAddressId = request.BillingAddressId,
                BillingContactId = request.BillingContactId,
                BillingCenterId = request.BillingCenterId,
                LocaleId = request.LocaleId,
                SendInvoice = request.SendInvoice,
                EmailInvoice = request.EmailInvoice,
                SendStatement = request.SendStatement,
                EmailStatement = request.EmailStatement,
                SendRenewal = request.SendRenewal,
                EmailRenewal = request.EmailRenewal,
                MarketingEmail = request.MarketingEmail,
                NotificationsMail = request.NotificationsMail,
                Instructions = request.Instructions ?? string.Empty,
                PrimaryNote = request.PrimaryNote ?? string.Empty,
                SecondaryNote = request.SecondaryNote ?? string.Empty,
                Name = request.Name,
                IsActive = request.IsActive,
                IsDeleted = request.IsDeleted,
                MasterAccountId = request.MasterAccountId,
                MasterAccountSubId = request.MasterAccountSubId,
                RegistrationNum = request.RegistrationNum ?? string.Empty,
                DiscountTypeId = request.DiscountTypeId,
                AccountManagerId = request.AccountManagerId,
                // Note: UtcTimestamp and CreatedBy should not be updated, only set on creation
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = user
            };
        }
    }
}
