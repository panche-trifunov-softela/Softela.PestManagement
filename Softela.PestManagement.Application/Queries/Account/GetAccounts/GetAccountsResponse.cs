using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Queries.Account.GetAccounts
{
    public class GetAccountsResponse
    {
        public List<AccountEntity> Data { get; set; }
    }
}
