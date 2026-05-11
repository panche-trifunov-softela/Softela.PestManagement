using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Estimate.DeleteEstimate;

public class DeleteEstimateHandler : IRequestHandler<DeleteEstimateRequest, bool>
{
    private readonly IEstimateRepository _estimateRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public DeleteEstimateHandler(
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

    public async Task<bool> Handle(DeleteEstimateRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _estimateRepository.DeleteAsync(request.Id, now, _tenantContext.UserId);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new EstimateDeletedEvent(request.Id), now));
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
