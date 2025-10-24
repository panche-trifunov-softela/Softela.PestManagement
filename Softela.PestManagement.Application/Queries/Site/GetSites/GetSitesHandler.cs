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
            if (request is null) throw new ArgumentNullException(nameof(request));

            var sites = request.AccountId.HasValue
                ? await _siteRepository.GetByAccountIdAsync(request.AccountId.Value)
                : await _siteRepository.GetAllAsync();

            return new GetSitesResponse
            {
                Data = sites
            };
        }
    }
}
