using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.ServiceAddress.UpdateServiceAddress;

public class UpdateServiceAddressHandler : IRequestHandler<UpdateServiceAddressRequest, bool>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly ITenantContext _tenantContext;

    public UpdateServiceAddressHandler(
        IServiceAddressRepository serviceAddressRepository,
        ITenantContext tenantContext)
    {
        _serviceAddressRepository = serviceAddressRepository;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateServiceAddressRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
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

        await _serviceAddressRepository.UpdateAsync(serviceAddress);
        return true;
    }
}
