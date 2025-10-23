using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Site.GetSiteById
{
    public class GetSiteByIdHandler : IRequestHandler<GetSiteByIdRequest, GetSiteByIdResponse>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ILogger<GetSiteByIdHandler> _logger;

        public GetSiteByIdHandler(ISiteRepository siteRepository, ILogger<GetSiteByIdHandler> logger)
        {
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetSiteByIdResponse> Handle(GetSiteByIdRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Retrieving site with Id={SiteId}", request.Id);

                var site = await _siteRepository.GetByIdAsync(request.Id);

                if (site == null)
                {
                    _logger.LogWarning("Site with ID {SiteId} not found", request.Id);
                }
                else
                {
                    _logger.LogInformation("Retrieved site with Id={SiteId}", request.Id);
                }

                return new GetSiteByIdResponse
                {
                    Data = site
                };
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Get site by ID operation was cancelled for Id={SiteId}", request.Id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving site with Id={SiteId}", request.Id);
                throw;
            }
        }
    }
}
