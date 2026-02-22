using MediatR;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Commands.Tenant.UpsertFeature;

public class UpsertFeatureHandler : IRequestHandler<UpsertFeatureRequest, bool>
{
    private readonly ITenantFeatureRepository _featureRepository;

    public UpsertFeatureHandler(ITenantFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<bool> Handle(UpsertFeatureRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var feature = new TenantFeature
        {
            TenantId = request.TenantId,
            FeatureKey = request.FeatureKey,
            IsEnabled = request.IsEnabled,
            CreatedAt = now,
            ModifiedAt = now
        };

        await _featureRepository.UpsertAsync(feature);
        return true;
    }
}
