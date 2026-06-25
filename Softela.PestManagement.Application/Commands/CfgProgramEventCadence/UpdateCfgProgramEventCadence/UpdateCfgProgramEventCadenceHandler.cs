using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.UpdateCfgProgramEventCadence;

public class UpdateCfgProgramEventCadenceHandler : IRequestHandler<UpdateCfgProgramEventCadenceRequest, bool>
{
    private readonly ICfgProgramEventCadenceRepository _cfgProgramEventCadenceRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCfgProgramEventCadenceHandler(
        ICfgProgramEventCadenceRepository cfgProgramEventCadenceRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgProgramEventCadenceRepository = cfgProgramEventCadenceRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCfgProgramEventCadenceRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgProgramEventCadence = UpdateCfgProgramEventCadenceMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgProgramEventCadenceRepository.UpdateAsync(cfgProgramEventCadence);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgProgramEventCadenceUpdatedEvent(cfgProgramEventCadence.Id, cfgProgramEventCadence.CfgProgramId), now));
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
