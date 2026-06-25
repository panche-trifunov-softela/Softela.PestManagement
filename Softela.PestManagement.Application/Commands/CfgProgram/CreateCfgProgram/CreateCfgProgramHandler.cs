using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgProgram.CreateCfgProgram;

public class CreateCfgProgramHandler : IRequestHandler<CreateCfgProgramRequest, int>
{
    private readonly ICfgProgramRepository _cfgProgramRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCfgProgramHandler(
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

    public async Task<int> Handle(CreateCfgProgramRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgProgram = CreateCfgProgramMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _cfgProgramRepository.CreateAsync(cfgProgram);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgProgramCreatedEvent(id, cfgProgram.TenantId, cfgProgram.Name), now));
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
