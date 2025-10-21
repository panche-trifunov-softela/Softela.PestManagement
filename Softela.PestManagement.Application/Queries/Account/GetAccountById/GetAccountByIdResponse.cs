using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Queries.Account.GetAccountById
{
    public class GetAccountByIdResponse
    {
        public AccountEntity? Account { get; set; }
    }
}
