using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Account.GetAccounts
{
    public class GetAccountsHandler : IRequestHandler<GetAccountsRequest, GetAccountsResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountsHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<GetAccountsResponse> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.SearchAsync(
                request.CompanyId,
                request.SearchTerm,
                request.IsActive
            );

            return new GetAccountsResponse
            {
                Accounts = accounts
            };
        }
    }
}
