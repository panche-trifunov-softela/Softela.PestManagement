using MediatR;
using Softela.PestManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

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
            var account = new AccountEntity
            {
                Id = request.Id,
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = Guid.NewGuid().ToString(),
                IsActive = (short)(request.IsActive ? 1 : 0),
                IsDeleted = request.IsDeleted,
                Name = request.Name,
            };

            await _accountRepository.UpsertAsync(account);
            return true;
        }
    }
}
