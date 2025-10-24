using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Site.GetSiteById
{
    public class GetSiteByIdHandler : IRequestHandler<GetSiteByIdRequest, GetSiteByIdResponse>
    {
        private readonly ISiteRepository _siteRepository;

        public GetSiteByIdHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        public async Task<GetSiteByIdResponse> Handle(GetSiteByIdRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var site = await _siteRepository.GetByIdAsync(request.Id);

            return new GetSiteByIdResponse
            {
                Data = site
            };
        }
    }
}
