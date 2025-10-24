using MediatR;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Site.DeleteSite
{
    public class DeleteSiteHandler : IRequestHandler<DeleteSiteRequest, bool>
    {
        private readonly ISiteRepository _siteRepository;

        public DeleteSiteHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        public async Task<bool> Handle(DeleteSiteRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            // Check if site exists
            var exists = await _siteRepository.ExistsAsync(request.Id);
            if (!exists)
            {
                return false;
            }

            // Soft delete
            await _siteRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
