using MediatR;

namespace Softela.PestManagement.Application.Commands.Account.DeleteAccount
{
    public sealed record DeleteAccountRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
