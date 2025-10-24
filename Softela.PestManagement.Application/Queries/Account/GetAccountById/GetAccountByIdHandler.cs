using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Account.GetAccountById
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdRequest, GetAccountByIdResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var account = await _accountRepository.GetByIdAsync(request.Id);

            return new GetAccountByIdResponse
            {
                Data = account
            };
        }
    }
}
