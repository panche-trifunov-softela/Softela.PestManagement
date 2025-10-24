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
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<bool> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var exists = await _accountRepository.ExistsAsync(request.Id);
            if (!exists)
            {
                return false;
            }

            // TODO: Get audit user from current user context
            var auditUser = "SYSTEM";

            var account = request.ToEntity(auditUser);

            var id = await _accountRepository.UpsertAsync(account);

            return id > 0;
        }
    }
}
