using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgProgram.UpdateCfgProgram;

public class UpdateCfgProgramHandler : IRequestHandler<UpdateCfgProgramRequest, bool>
{
    private readonly ICfgProgramRepository _cfgProgramRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCfgProgramHandler(
        ICfgProgramRepository cfgProgramRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgProgramRepository = cfgProgramRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCfgProgramRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgProgram = UpdateCfgProgramMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgProgramRepository.UpdateAsync(cfgProgram);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgProgramUpdatedEvent(cfgProgram.Id, cfgProgram.TenantId, cfgProgram.Name), now));
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
