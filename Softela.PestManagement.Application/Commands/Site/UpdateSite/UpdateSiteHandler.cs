using MediatR;
using Softela.PestManagement.Application.Commands.Account.UpdateAccount;
using Softela.PestManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteEntity = Softela.PestManagement.Domain.Entities.Site;

namespace Softela.PestManagement.Application.Commands.Site.UpdateSite
{
    public class UpdateSiteHandler : IRequestHandler<UpdateSiteRequest, bool>
    {
        private readonly ISiteRepository _siteRepository;

        public UpdateSiteHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public async Task<bool> Handle(UpdateSiteRequest request, CancellationToken cancellationToken)
        {
            var site = new SiteEntity
            {
                Id = request.Id,
                UtcLastChanged = DateTime.UtcNow,
                LastChangedBy = Guid.NewGuid().ToString(),
                IsDeleted = request.IsDeleted,
                SiteReferenceNumber = request.ReferenceNumber,
                AccountId = request.AccountId
            };

            await _siteRepository.UpsertAsync(site);
            return true;
        }
    }
}
