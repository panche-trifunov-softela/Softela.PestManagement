using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.CreateCfgProgramEventCadence;

public class CreateCfgProgramEventCadenceHandler : IRequestHandler<CreateCfgProgramEventCadenceRequest, int>
{
    private readonly ICfgProgramEventCadenceRepository _cfgProgramEventCadenceRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCfgProgramEventCadenceHandler(
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

    public async Task<int> Handle(CreateCfgProgramEventCadenceRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgProgramEventCadence = CreateCfgProgramEventCadenceMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _cfgProgramEventCadenceRepository.CreateAsync(cfgProgramEventCadence);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgProgramEventCadenceCreatedEvent(id, cfgProgramEventCadence.TenantId, cfgProgramEventCadence.CfgProgramId), now));
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
