using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Account.DeleteAccount
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountRequest, bool>
    {
        private readonly IAccountRepository _accountRepository;

        public DeleteAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<bool> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            // Check if account exists
            var exists = await _accountRepository.ExistsAsync(request.Id);
            if (!exists)
            {
                return false;
            }

            // Soft delete
            await _accountRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
