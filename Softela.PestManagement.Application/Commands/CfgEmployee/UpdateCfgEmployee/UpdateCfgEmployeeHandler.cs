using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgEmployee.UpdateCfgEmployee;

public class UpdateCfgEmployeeHandler : IRequestHandler<UpdateCfgEmployeeRequest, bool>
{
    private readonly ICfgEmployeeRepository _cfgEmployeeRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCfgEmployeeHandler(
        ICfgEmployeeRepository cfgEmployeeRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgEmployeeRepository = cfgEmployeeRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCfgEmployeeRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgEmployee = UpdateCfgEmployeeMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgEmployeeRepository.UpdateAsync(cfgEmployee);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgEmployeeUpdatedEvent(cfgEmployee.Id, cfgEmployee.TenantId, cfgEmployee.Name), now));
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
