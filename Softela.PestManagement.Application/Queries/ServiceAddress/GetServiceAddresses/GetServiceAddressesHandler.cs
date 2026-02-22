using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Dtos;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddresses;

public class GetServiceAddressesHandler : IRequestHandler<GetServiceAddressesRequest, GetServiceAddressesResponse>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly ITenantContext _tenantContext;

    public GetServiceAddressesHandler(
        IServiceAddressRepository serviceAddressRepository,
        ITenantContext tenantContext)
    {
        _serviceAddressRepository = serviceAddressRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetServiceAddressesResponse> Handle(GetServiceAddressesRequest request, CancellationToken cancellationToken)
    {
        var serviceAddresses = await _serviceAddressRepository.GetByCustomerIdAsync(request.CustomerId, _tenantContext.TenantId);

        var dtos = serviceAddresses.Select(sa => new ServiceAddressDto
        {
            Id = sa.Id,
            CustomerId = sa.CustomerId,
            ServiceAddressName = sa.ServiceAddressName,
            ServiceAddressType = sa.ServiceAddressType,
            Address = sa.Address,
            City = sa.City,
            State = sa.State,
            Zip = sa.Zip,
            ContactName = sa.ContactName,
            ContactPhone = sa.ContactPhone,
            ContactEmail = sa.ContactEmail,
            IsActive = sa.IsActive,
            CreatedAt = sa.CreatedAt,
            ModifiedAt = sa.ModifiedAt
        }).ToList();

        return new GetServiceAddressesResponse { Data = dtos };
    }
}
