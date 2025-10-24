using MediatR;

namespace Softela.PestManagement.Application.Queries.Account.GetAccountById
{
    public class GetAccountByIdRequest : IRequest<GetAccountByIdResponse>
    {
        public int Id { get; set; }
    }
}
