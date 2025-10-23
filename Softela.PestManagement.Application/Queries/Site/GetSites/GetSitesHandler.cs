using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Site.GetSites
{
    public class GetSitesHandler : IRequestHandler<GetSitesRequest, GetSitesResponse>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ILogger<GetSitesHandler> _logger;

        public GetSitesHandler(ISiteRepository siteRepository, ILogger<GetSitesHandler> logger)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetSitesResponse> Handle(GetSitesRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Retrieving all sites");

                var sites = await _siteRepository.GetAllAsync();

                _logger.LogInformation("Retrieved {SiteCount} sites", sites.Count());
                return new GetSitesResponse
                {
                    Data = sites.ToList()
                };
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Get sites operation was cancelled");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sites");
                throw;
            }
        }
    }
}
