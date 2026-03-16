using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.ServiceAddress.CreateServiceAddress;

public class CreateServiceAddressHandler : IRequestHandler<CreateServiceAddressRequest, int>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly ITenantContext _tenantContext;

    public CreateServiceAddressHandler(
        IServiceAddressRepository serviceAddressRepository,
        ITenantContext tenantContext)
    {
        _serviceAddressRepository = serviceAddressRepository;
        _tenantContext = tenantContext;
    }

    public async Task<int> Handle(CreateServiceAddressRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var userId = _tenantContext.UserId;

        var serviceAddress = new Domain.Entities.ServiceAddress
        {
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
            IsDeleted = false,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };

        return await _serviceAddressRepository.CreateAsync(serviceAddress);
    }
}
