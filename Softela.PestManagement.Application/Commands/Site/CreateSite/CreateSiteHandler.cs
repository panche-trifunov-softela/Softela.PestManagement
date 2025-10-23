using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Commands.Site.Shared;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Site.CreateSite
{
    public class CreateSiteHandler : IRequestHandler<CreateSiteRequest, int>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ILogger<CreateSiteHandler> _logger;

        public CreateSiteHandler(ISiteRepository siteRepository, ILogger<CreateSiteHandler> logger)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateSiteRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Creating site with ReferenceNumber={ReferenceNumber}",
                    request.ReferenceNumber);

                var userId = Guid.NewGuid(); // TODO: Get from current user context

                var site = request.ToEntity(userId);
                var siteId = await _siteRepository.UpsertAsync(site);

                _logger.LogInformation("Site created successfully with Id={SiteId}", siteId);
                return siteId;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Create site operation was cancelled for ReferenceNumber={ReferenceNumber}", request.ReferenceNumber);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating site with ReferenceNumber={ReferenceNumber}",
                    request.ReferenceNumber);
                throw;
            }
        }
    }
}
