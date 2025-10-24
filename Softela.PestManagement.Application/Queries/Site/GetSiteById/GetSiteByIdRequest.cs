using MediatR;

namespace Softela.PestManagement.Application.Queries.Site.GetSiteById
{
    public class GetSiteByIdRequest : IRequest<GetSiteByIdResponse>
    {
        public int Id { get; set; }
    }
}
