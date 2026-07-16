using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgRoute.CreateCfgRoute;

public class CreateCfgRouteHandler : IRequestHandler<CreateCfgRouteRequest, int>
{
    private readonly ICfgRouteRepository _cfgRouteRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCfgRouteHandler(
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

    public async Task<int> Handle(CreateCfgRouteRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgRoute = CreateCfgRouteMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _cfgRouteRepository.CreateAsync(cfgRoute);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgRouteCreatedEvent(id, cfgRoute.TenantId, cfgRoute.CfgEmployeeId), now));
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
