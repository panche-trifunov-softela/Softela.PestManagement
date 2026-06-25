using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgEvent.UpdateCfgEvent;

public class UpdateCfgEventHandler : IRequestHandler<UpdateCfgEventRequest, bool>
{
    private readonly ICfgEventRepository _cfgEventRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCfgEventHandler(
        ICfgEventRepository cfgEventRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgEventRepository = cfgEventRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCfgEventRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgEvent = UpdateCfgEventMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgEventRepository.UpdateAsync(cfgEvent);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgEventUpdatedEvent(cfgEvent.Id, cfgEvent.TenantId, cfgEvent.Name), now));
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
