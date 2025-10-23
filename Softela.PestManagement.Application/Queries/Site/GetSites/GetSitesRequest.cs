using MediatR;

namespace Softela.PestManagement.Application.Queries.Site.GetSites
{
    public class GetSitesRequest : IRequest<GetSitesResponse>
    {
        public string? Search { get; set; }
    }
}
