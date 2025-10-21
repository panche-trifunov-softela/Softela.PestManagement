using MediatR;
using Softela.PestManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteEntity = Softela.PestManagement.Domain.Entities.Site;

namespace Softela.PestManagement.Application.Commands.Site.CreateSite
{
    public class CreateSiteHandler : IRequestHandler<CreateSiteRequest, bool>
    {
        private readonly ISiteRepository _siteRepository;

        public CreateSiteHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public async Task<bool> Handle(CreateSiteRequest request, CancellationToken cancellationToken)
        {
            var site = new SiteEntity
            {
                Id = 0,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                ReferenceNumber = request.ReferenceNumber,
            };

            await _siteRepository.CreateUpdateSiteAsync(site);
            return true;
        }
    }
}
