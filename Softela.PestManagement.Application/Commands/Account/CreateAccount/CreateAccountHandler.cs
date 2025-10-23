using MediatR;
using Softela.PestManagement.Application.Commands.Account.Shared;
using Softela.PestManagement.Application.Repositories;

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
            var now = DateTime.UtcNow;
            var userId = Guid.NewGuid(); // TODO: Get from current user context

            var account = AccountMapper.ToEntity(request, userId, now);

            var accountId = await _accountRepository.UpsertAsync(account);
            return accountId;
        }
    }
}
