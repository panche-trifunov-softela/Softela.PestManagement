using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Estimate.CreateEstimate;

public class CreateEstimateHandler : IRequestHandler<CreateEstimateRequest, int>
{
    private readonly IEstimateRepository _estimateRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateEstimateHandler(
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

    public async Task<int> Handle(CreateEstimateRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var estimate = CreateEstimateMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _estimateRepository.CreateAsync(estimate);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(new EstimateCreatedEvent(id, estimate.ServiceAddressId), now));
            await _unitOfWork.CommitAsync(cancellationToken);
            return id;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
