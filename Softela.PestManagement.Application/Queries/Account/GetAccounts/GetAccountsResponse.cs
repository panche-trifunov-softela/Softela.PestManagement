using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Queries.Account.GetAccounts
{
    public class GetAccountsResponse
    {
        public IEnumerable<AccountEntity> Accounts { get; set; } = new List<AccountEntity>();
    }
}
