using MediatR;

namespace Softela.PestManagement.Application.Queries.Account.GetAccounts
{
    public class GetAccountsRequest : IRequest<GetAccountsResponse>
    {
        public int CompanyId { get; set; }
        public string? SearchTerm { get; set; }
        public short? IsActive { get; set; }
    }
}
