using MediatR;
using Softela.PestManagement.Application.Commands.Site.Shared;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Site.UpdateSite
{
    public class UpdateSiteHandler : IRequestHandler<UpdateSiteRequest, bool>
    {
        private readonly ISiteRepository _siteRepository;

        public UpdateSiteHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        public async Task<bool> Handle(UpdateSiteRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            // Check if site exists
            var exists = await _siteRepository.ExistsAsync(request.Id);
            if (!exists)
            {
                return false;
            }

            // TODO: Get audit user from current user context
            var auditUser = "SYSTEM";

            var site = request.ToEntity(auditUser);

            var id = await _siteRepository.UpsertAsync(site);

            return id > 0;
        }
    }
}
