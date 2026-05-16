using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Estimate.UpdateEstimate;

public class UpdateEstimateHandler : IRequestHandler<UpdateEstimateRequest, bool>
{
    private readonly IEstimateRepository _estimateRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateEstimateHandler(
        IEstimateRepository estimateRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _estimateRepository = estimateRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateEstimateRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var nowOffset = DateTimeOffset.UtcNow;
        var userId = _tenantContext.UserId;

        var estimate = UpdateEstimateMapper.ToDomainEntity(request, now, userId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _estimateRepository.UpdateAsync(estimate);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new EstimateUpdatedEvent(estimate.Id, estimate.ServiceAddressId), nowOffset));
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
