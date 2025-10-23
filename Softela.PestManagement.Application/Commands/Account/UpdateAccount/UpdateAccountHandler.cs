using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Commands.Account.Shared;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Account.UpdateAccount
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountRequest, bool>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<UpdateAccountHandler> _logger;

        public UpdateAccountHandler(IAccountRepository accountRepository, ILogger<UpdateAccountHandler> logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Updating account with Id={AccountId}, AccountNum={AccountNum}",
                    request.Id, request.AccountNum);

                var existingAccount = await _accountRepository.GetByIdAsync(request.Id);
                if (existingAccount == null)
                {
                    _logger.LogWarning("Account with ID {AccountId} not found", request.Id);
                    throw new InvalidOperationException($"Account with ID {request.Id} not found.");
                }

                var userId = Guid.NewGuid(); // TODO: Get from current user context

                var account = request.ToEntity(userId, existingAccount.CreatedAt, existingAccount.CreatedBy);

                var accountId = await _accountRepository.UpsertAsync(account);

                _logger.LogInformation("Account updated successfully with Id={AccountId}", accountId);
                return accountId > 0;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Update account operation was cancelled for Id={AccountId}", request.Id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating account with Id={AccountId}, AccountNum={AccountNum}",
                    request.Id, request.AccountNum);
                throw;
            }
        }
    }
}
