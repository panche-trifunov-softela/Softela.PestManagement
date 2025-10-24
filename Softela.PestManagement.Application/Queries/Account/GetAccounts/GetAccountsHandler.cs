using MediatR;
using Softela.PestManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (request is null) throw new ArgumentNullException(nameof(request));

            var accounts = await _accountRepository.SearchAsync(
                request.CompanyId,
                request.SearchTerm,
                request.IsActive
            );

            return new GetAccountsResponse
            {
                Data = accounts
            };
        }
    }
}
