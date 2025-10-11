using MediatR;
using Softela.PestManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Commands.Account.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountRequest, bool>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var account = new AccountEntity 
            {
                Id = 0,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                IsActive = request.IsActive,
                Name = request.Name,
            };

            await _accountRepository.CreateUpdateAccountAsync(account);
            return true;
        }
    }
}
