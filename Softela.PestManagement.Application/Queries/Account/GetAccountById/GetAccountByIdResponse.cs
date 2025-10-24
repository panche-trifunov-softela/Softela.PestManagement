using AccountEntity = Softela.PestManagement.Domain.Entities.Account;

namespace Softela.PestManagement.Application.Queries.Account.GetAccountById
{
    public class GetAccountByIdResponse
    {
        public AccountEntity? Data { get; set; }
    }
}
