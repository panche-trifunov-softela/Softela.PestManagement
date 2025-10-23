using MediatR;

namespace Softela.PestManagement.Application.Commands.Site.DeleteSite
{
    public sealed record DeleteSiteRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
