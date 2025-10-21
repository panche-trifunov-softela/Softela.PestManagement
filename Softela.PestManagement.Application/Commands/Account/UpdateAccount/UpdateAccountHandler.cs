using MediatR;
using Softela.PestManagement.Application.Repositories;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Commands.Account.UpdateAccount
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountRequest, bool>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            // Check if account exists
            var existingAccount = await _accountRepository.GetByIdAsync(request.Id);
            if (existingAccount == null)
            {
                throw new InvalidOperationException($"Account with ID {request.Id} not found.");
            }

            // Validate account number uniqueness (excluding current account)
            var accountNumExists = await _accountRepository.AccountNumExistsAsync(
                request.AccountNum,
                request.CompanyId,
                request.Id
            );

            if (accountNumExists)
            {
                throw new InvalidOperationException($"Account number '{request.AccountNum}' already exists for this company.");
            }

            var userId = Guid.NewGuid(); // TODO: Get from current user context

            var account = new AccountEntity
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
                CreatedAt = existingAccount.CreatedAt,
                CreatedBy = existingAccount.CreatedBy,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = userId
            };

            await _accountRepository.UpdateAsync(account);
            return true;
        }
    }
}
