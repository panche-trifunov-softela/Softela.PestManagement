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
                UtcTimestamp = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid().ToString(),
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = Guid.NewGuid().ToString(),
                IsActive = (short)(request.IsActive ? 1 : 0),
                Name = request.Name,
            };

            await _accountRepository.UpsertAsync(account);
            return true;
        }
    }
}
