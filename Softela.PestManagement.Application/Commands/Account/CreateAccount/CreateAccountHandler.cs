using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Commands.Account.Shared;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Account.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountRequest, int>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<CreateAccountHandler> _logger;

        public CreateAccountHandler(IAccountRepository accountRepository, ILogger<CreateAccountHandler> logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Creating account with AccountNum={AccountNum}, CompanyId={CompanyId}",
                    request.AccountNum, request.CompanyId);

                var userId = Guid.NewGuid(); // TODO: Get from current user context

                var account = request.ToEntity(userId);
                var accountId = await _accountRepository.UpsertAsync(account);

                _logger.LogInformation("Account created successfully with Id={AccountId}", accountId);
                return accountId;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Create account operation was cancelled for AccountNum={AccountNum}", request.AccountNum);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating account with AccountNum={AccountNum}, CompanyId={CompanyId}",
                    request.AccountNum, request.CompanyId);
                throw;
            }
        }
    }
}
