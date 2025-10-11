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
            var account = new SiteEntity
            {
                Id = request.Id,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = Guid.NewGuid(),
                IsDeleted = request.IsDeleted,
                 ReferenceNumber = request.ReferenceNumber,
                    AccountId = request.AccountId
            };

            await _siteRepository.CreateUpdateSiteAsync(account);
            return true;
        }
    }
}
