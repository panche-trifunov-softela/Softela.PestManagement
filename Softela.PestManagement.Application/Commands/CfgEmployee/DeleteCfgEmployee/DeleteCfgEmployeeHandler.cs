using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgEmployee.DeleteCfgEmployee;

public class DeleteCfgEmployeeHandler : IRequestHandler<DeleteCfgEmployeeRequest, bool>
{
    private readonly ICfgEmployeeRepository _cfgEmployeeRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public DeleteCfgEmployeeHandler(
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

    public async Task<bool> Handle(DeleteCfgEmployeeRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgEmployeeRepository.DeleteAsync(request.Id, _tenantContext.TenantId, now, _tenantContext.UserId);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgEmployeeDeletedEvent(request.Id, _tenantContext.TenantId), now));
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
