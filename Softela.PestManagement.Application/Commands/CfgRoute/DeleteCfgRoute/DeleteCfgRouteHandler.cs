using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgRoute.DeleteCfgRoute;

public class DeleteCfgRouteHandler : IRequestHandler<DeleteCfgRouteRequest, bool>
{
    private readonly ICfgRouteRepository _cfgRouteRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public DeleteCfgRouteHandler(
        ICfgRouteRepository cfgRouteRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _cfgRouteRepository = cfgRouteRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(DeleteCfgRouteRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgRouteRepository.DeleteAsync(request.Id, _tenantContext.TenantId, now, _tenantContext.UserId);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgRouteDeletedEvent(request.Id, _tenantContext.TenantId), now));
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
