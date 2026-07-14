using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.CfgEmployee.CreateCfgEmployee;

public class CreateCfgEmployeeHandler : IRequestHandler<CreateCfgEmployeeRequest, int>
{
    private readonly ICfgEmployeeRepository _cfgEmployeeRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCfgEmployeeHandler(
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

    public async Task<int> Handle(CreateCfgEmployeeRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        var cfgEmployee = CreateCfgEmployeeMapper.ToDomainEntity(request, now, _tenantContext.UserId, _tenantContext.TenantId);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = await _cfgEmployeeRepository.CreateAsync(cfgEmployee);
            await _outboxRepository.InsertAsync(
                OutboxMessageFactory.Create(new CfgEmployeeCreatedEvent(id, cfgEmployee.TenantId, cfgEmployee.Name), now));
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
