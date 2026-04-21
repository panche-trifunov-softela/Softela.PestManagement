using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.ServiceAddress.UpdateServiceAddress;

public class UpdateServiceAddressHandler : IRequestHandler<UpdateServiceAddressRequest, bool>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateServiceAddressHandler(
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

    public async Task<bool> Handle(UpdateServiceAddressRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var nowOffset = DateTimeOffset.UtcNow;
        var userId = _tenantContext.UserId;

        var serviceAddress = new Domain.Entities.ServiceAddress
        {
            Id = request.Id,
            TenantId = _tenantContext.TenantId,
            CustomerId = request.CustomerId,
            ServiceAddressName = request.ServiceAddressName,
            ServiceAddressType = request.ServiceAddressType,
            Address = request.Address,
            City = request.City,
            State = request.State,
            Zip = request.Zip,
            ContactName = request.ContactName,
            ContactPhone = request.ContactPhone,
            ContactEmail = request.ContactEmail,
            IsActive = request.IsActive,
            ModifiedAt = now,
            ModifiedBy = userId
        };

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _serviceAddressRepository.UpdateAsync(serviceAddress);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new ServiceAddressUpdatedEvent(serviceAddress.Id, serviceAddress.CustomerId, serviceAddress.TenantId), nowOffset));
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
