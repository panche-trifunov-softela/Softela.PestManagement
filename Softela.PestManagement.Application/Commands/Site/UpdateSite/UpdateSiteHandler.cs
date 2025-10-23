using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Commands.Site.Shared;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Site.UpdateSite
{
    public class UpdateSiteHandler : IRequestHandler<UpdateSiteRequest, bool>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ILogger<UpdateSiteHandler> _logger;

        public UpdateSiteHandler(ISiteRepository siteRepository, ILogger<UpdateSiteHandler> logger)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateSiteRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Updating site with Id={SiteId}, ReferenceNumber={ReferenceNumber}",
                    request.Id, request.ReferenceNumber);

                var existingSite = await _siteRepository.GetByIdAsync(request.Id);
                if (existingSite == null)
                {
                    _logger.LogWarning("Site with ID {SiteId} not found", request.Id);
                    throw new InvalidOperationException($"Site with ID {request.Id} not found.");
                }

                var userId = Guid.NewGuid(); // TODO: Get from current user context

                var site = request.ToEntity(userId, existingSite.CreatedAt, existingSite.CreatedBy);
                var siteId = await _siteRepository.UpsertAsync(site);

                _logger.LogInformation("Site updated successfully with Id={SiteId}", siteId);
                return siteId > 0;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Update site operation was cancelled for Id={SiteId}", request.Id);
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating site with Id={SiteId}, ReferenceNumber={ReferenceNumber}",
                    request.Id, request.ReferenceNumber);
                throw;
            }
        }
    }
}
