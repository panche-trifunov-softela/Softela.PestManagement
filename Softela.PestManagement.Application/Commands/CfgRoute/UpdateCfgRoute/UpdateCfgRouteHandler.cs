using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgRoute.UpdateCfgRoute;

public class UpdateCfgRouteHandler : IRequestHandler<UpdateCfgRouteRequest, bool>
{
    private readonly ICfgRouteRepository _cfgRouteRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCfgRouteHandler(
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

    public async Task<bool> Handle(UpdateCfgRouteRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgRoute = UpdateCfgRouteMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _cfgRouteRepository.UpdateAsync(cfgRoute);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgRouteUpdatedEvent(cfgRoute.Id, cfgRoute.TenantId, cfgRoute.CfgEmployeeId), now));
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
