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
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<int> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            // TODO: Get audit user from current user context
            var auditUser = "SYSTEM";

            var account = request.ToEntity(auditUser);

            var id = await _accountRepository.UpsertAsync(account);

            return id;
        }
    }
}
