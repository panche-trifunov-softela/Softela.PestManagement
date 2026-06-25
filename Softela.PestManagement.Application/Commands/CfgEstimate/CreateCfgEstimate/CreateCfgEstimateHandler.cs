using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgEstimate.CreateCfgEstimate;

public class CreateCfgEstimateHandler : IRequestHandler<CreateCfgEstimateRequest, int>
{
    private readonly ICfgEstimateRepository _cfgEstimateRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCfgEstimateHandler(
        ICfgEstimateRepository cfgEstimateRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgEstimateRepository = cfgEstimateRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<int> Handle(CreateCfgEstimateRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgEstimate = CreateCfgEstimateMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _cfgEstimateRepository.CreateAsync(cfgEstimate);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgEstimateCreatedEvent(id, cfgEstimate.TenantId, cfgEstimate.Name), now));
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
