using MediatR;
using Softela.PestManagement.Application.Commands.Site.Shared;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Site.CreateSite
{
    public class CreateSiteHandler : IRequestHandler<CreateSiteRequest, int>
    {
        private readonly ISiteRepository _siteRepository;

        public CreateSiteHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        public async Task<int> Handle(CreateSiteRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            // TODO: Get audit user from current user context
            var auditUser = "SYSTEM";

            var site = request.ToEntity(auditUser);

            var id = await _siteRepository.UpsertAsync(site);

            return id;
        }
    }
}
