using MediatR;

namespace Softela.PestManagement.Application.Commands.Site.CreateSite
{
    public sealed record CreateSiteRequest : IRequest<int>
    {
        public string ReferenceNumber { get; set; }

        public bool IsActive { get; set; }

        public int AccountId { get; set; }
    }
}
