using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.ServiceAddress.DeleteServiceAddress;

public class DeleteServiceAddressHandler : IRequestHandler<DeleteServiceAddressRequest, bool>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public DeleteServiceAddressHandler(
        IServiceAddressRepository serviceAddressRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _serviceAddressRepository = serviceAddressRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(DeleteServiceAddressRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _serviceAddressRepository.DeleteAsync(request.Id, _tenantContext.TenantId, now, _tenantContext.UserId);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new ServiceAddressDeletedEvent(request.Id, _tenantContext.TenantId), now));
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
