using Softela.PestManagement.Application.Commands.Account.CreateAccount;
using Softela.PestManagement.Application.Commands.Account.UpdateAccount;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Commands.Account.Shared
{
    public static class AccountMapper
    {
        public static AccountEntity ToEntity(CreateAccountRequest request, Guid userId, DateTime now)
        {
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
                CreatedBy = userId,
                ModifiedBy = userId
            };
        }

        public static AccountEntity ToEntity(UpdateAccountRequest request, Guid userId, DateTime createdAt, Guid createdBy)
        {
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
                CreatedAt = createdAt,
                CreatedBy = createdBy,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = userId
            };
        }
    }
}
