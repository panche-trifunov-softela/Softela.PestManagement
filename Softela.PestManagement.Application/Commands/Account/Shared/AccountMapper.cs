using Softela.PestManagement.Application.Commands.Account.CreateAccount;
using Softela.PestManagement.Application.Commands.Account.UpdateAccount;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Commands.Account.Shared
{
    public static class AccountMapper
    {
        /// <summary>
        /// Map CreateAccountRequest
        /// </summary>
        public static AccountEntity ToEntity(this CreateAccountRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            return new AccountEntity
            {
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
                Name = request.Name ?? string.Empty,
                IsActive = request.IsActive,
                IsDeleted = request.IsDeleted,
                MasterAccountId = request.MasterAccountId,
                MasterAccountSubId = request.MasterAccountSubId,
                RegistrationNum = request.RegistrationNum ?? string.Empty,
                DiscountTypeId = request.DiscountTypeId,
                AccountManagerId = request.AccountManagerId,
                CreatedAt = now,
                ModifiedAt = now,
                CreatedBy = user,
                ModifiedBy = user
            };
        }

        /// <summary>
        /// Map UpdateAccountRequest
        /// </summary>
        public static AccountEntity ToEntity(this UpdateAccountRequest request, Guid? auditUser = null, DateTime? createdAt = null, Guid? createdBy = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;
            var created = createdAt ?? now;
            var creator = createdBy ?? user;

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
                Name = request.Name ?? string.Empty,
                IsActive = request.IsActive,
                IsDeleted = request.IsDeleted,
                MasterAccountId = request.MasterAccountId,
                MasterAccountSubId = request.MasterAccountSubId,
                RegistrationNum = request.RegistrationNum ?? string.Empty,
                DiscountTypeId = request.DiscountTypeId,
                AccountManagerId = request.AccountManagerId,
                CreatedAt = created,
                CreatedBy = creator,
                ModifiedAt = now,
                ModifiedBy = user
            };
        }
    }
}
