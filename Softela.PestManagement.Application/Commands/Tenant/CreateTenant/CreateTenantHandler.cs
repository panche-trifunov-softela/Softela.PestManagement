using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Tenant.CreateTenant;

public class CreateTenantHandler : IRequestHandler<CreateTenantRequest, int>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateTenantHandler(
        ITenantRepository tenantRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _tenantRepository = tenantRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<int> Handle(CreateTenantRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var tenant = new Domain.Entities.Tenant
        {
            Id = 0,
            Name = request.Name,
            Slug = request.Slug,
            IsActive = true,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = _tenantContext.UserId,
            ModifiedBy = _tenantContext.UserId
        };

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var tenantId = await _tenantRepository.UpsertAsync(tenant);

            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new TenantUpsertedEvent(tenantId, request.Name, request.Slug), DateTimeOffset.UtcNow));

            await _unitOfWork.CommitAsync(cancellationToken);
            return tenantId;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
