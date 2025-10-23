using MediatR;

namespace Softela.PestManagement.Application.Queries.Site.GetSiteById
{
    public sealed record GetSiteByIdRequest : IRequest<GetSiteByIdResponse>
    {
        public int Id { get; set; }
    }
}
