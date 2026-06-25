using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgCadence.CreateCfgCadence;

public class CreateCfgCadenceHandler : IRequestHandler<CreateCfgCadenceRequest, int>
{
    private readonly ICfgCadenceRepository _cfgCadenceRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCfgCadenceHandler(
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

    public async Task<int> Handle(CreateCfgCadenceRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgCadence = CreateCfgCadenceMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _cfgCadenceRepository.CreateAsync(cfgCadence);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgCadenceCreatedEvent(id, cfgCadence.TenantId, cfgCadence.Name), now));
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
