using MediatR;
using Softela.PestManagement.Application.Repositories;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Commands.Account.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountRequest, int>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            // Validate account number uniqueness
            var accountNumExists = await _accountRepository.AccountNumExistsAsync(
                request.AccountNum,
                request.CompanyId
            );

            if (accountNumExists)
            {
                throw new InvalidOperationException($"Account number '{request.AccountNum}' already exists for this company.");
            }

            var now = DateTime.UtcNow;
            var userId = Guid.NewGuid(); // TODO: Get from current user context

            var account = new AccountEntity
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

            var accountId = await _accountRepository.CreateAsync(account);
            return accountId;
        }
    }
}
