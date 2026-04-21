using MediatR;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Commands.Tenant.UpsertFeature;

public class UpsertFeatureHandler : IRequestHandler<UpsertFeatureRequest, bool>
{
    private readonly ITenantFeatureRepository _featureRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpsertFeatureHandler(
        ITenantFeatureRepository featureRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork)
    {
        _featureRepository = featureRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _featureRepository.UpsertAsync(feature);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new TenantFeatureUpsertedEvent(feature.TenantId, feature.FeatureKey, feature.IsEnabled), DateTimeOffset.UtcNow));
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
