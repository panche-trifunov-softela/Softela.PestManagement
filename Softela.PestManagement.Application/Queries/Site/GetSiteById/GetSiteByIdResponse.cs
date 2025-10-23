using SiteEntity = Softela.PestManagement.Domain.Entities.Site;

namespace Softela.PestManagement.Application.Queries.Site.GetSiteById
{
    public class GetSiteByIdResponse
    {
        public SiteEntity? Data { get; set; }
    }
}
