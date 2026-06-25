using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgCadence.UpdateCfgCadence;

public class UpdateCfgCadenceHandler : IRequestHandler<UpdateCfgCadenceRequest, bool>
{
    private readonly ICfgCadenceRepository _cfgCadenceRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCfgCadenceHandler(
        ICfgCadenceRepository cfgCadenceRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgCadenceRepository = cfgCadenceRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCfgCadenceRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgCadence = UpdateCfgCadenceMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgCadenceRepository.UpdateAsync(cfgCadence);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgCadenceUpdatedEvent(cfgCadence.Id, cfgCadence.TenantId, cfgCadence.Name), now));
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
