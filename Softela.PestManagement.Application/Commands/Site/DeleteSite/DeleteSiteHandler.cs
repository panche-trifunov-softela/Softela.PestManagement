using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Site.DeleteSite
{
    public class DeleteSiteHandler : IRequestHandler<DeleteSiteRequest, bool>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ILogger<DeleteSiteHandler> _logger;

        public DeleteSiteHandler(ISiteRepository siteRepository, ILogger<DeleteSiteHandler> logger)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteSiteRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Deleting site with Id={SiteId}", request.Id);

                var exists = await _siteRepository.ExistsAsync(request.Id);
                if (!exists)
                {
                    _logger.LogWarning("Site with ID {SiteId} not found", request.Id);
                    throw new InvalidOperationException($"Site with ID {request.Id} not found.");
                }

                await _siteRepository.DeleteAsync(request.Id);

                _logger.LogInformation("Site deleted successfully with Id={SiteId}", request.Id);
                return true;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Delete site operation was cancelled for Id={SiteId}", request.Id);
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting site with Id={SiteId}", request.Id);
                throw;
            }
        }
    }
}
