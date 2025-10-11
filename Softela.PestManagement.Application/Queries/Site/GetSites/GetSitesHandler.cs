using MediatR;
using Softela.PestManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Queries.Site.GetSites
{
    public class GetSitesHandler : IRequestHandler<GetSitesRequest, GetSitesResponse>
    {
        private readonly ISiteRepository _siteRepository;

        public GetSitesHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public async Task<GetSitesResponse> Handle(GetSitesRequest request, CancellationToken cancellationToken)
        {
            var sites = await _siteRepository.GetSitesAsync();
            return new GetSitesResponse
            {
                Data = sites
            };
        }
    }
}
