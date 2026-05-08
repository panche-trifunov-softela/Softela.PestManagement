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
        var now = DateTime.UtcNow;
        var nowOffset = DateTimeOffset.UtcNow;
        var userId = _tenantContext.UserId;

        var estimate = new Domain.Entities.Estimate
        {
            ServiceAddressId = request.ServiceAddressId,
            Name = request.Name,
            Status = request.Status,
            ServiceInterest = request.ServiceInterest,
            AssignedSalesRep = request.AssignedSalesRep,
            Source = request.Source,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _estimateRepository.CreateAsync(estimate);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new EstimateCreatedEvent(id, estimate.ServiceAddressId), nowOffset));
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
