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
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = Guid.NewGuid(),
                IsActive = request.IsActive,
                IsDeleted = request.IsDeleted,
                Name = request.Name,
            };

            await _accountRepository.CreateUpdateAccountAsync(account);
            return true;
        }
    }
}
