using MediatR;
using Softela.PestManagement.Application.Commands.Account.Shared;
using Softela.PestManagement.Application.Repositories;

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
            var existingAccount = await _accountRepository.GetByIdAsync(request.Id);
            if (existingAccount == null)
            {
                throw new InvalidOperationException($"Account with ID {request.Id} not found.");
            }

            var userId = Guid.NewGuid(); // TODO: Get from current user context

            var account = AccountMapper.ToEntity(
                request,
                userId,
                existingAccount.CreatedAt,
                existingAccount.CreatedBy
            );

            var accountId = await _accountRepository.UpsertAsync(account);
            return accountId > 0;
        }
    }
}
