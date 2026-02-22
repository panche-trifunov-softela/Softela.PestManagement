using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Dtos;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddressById;

public class GetServiceAddressByIdHandler : IRequestHandler<GetServiceAddressByIdRequest, GetServiceAddressByIdResponse>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly ITenantContext _tenantContext;

    public GetServiceAddressByIdHandler(
        IServiceAddressRepository serviceAddressRepository,
        ITenantContext tenantContext)
    {
        _serviceAddressRepository = serviceAddressRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetServiceAddressByIdResponse> Handle(GetServiceAddressByIdRequest request, CancellationToken cancellationToken)
    {
        var serviceAddress = await _serviceAddressRepository.GetByIdAsync(request.Id, _tenantContext.TenantId);
        if (serviceAddress == null)
            return new GetServiceAddressByIdResponse { Data = null };

        return new GetServiceAddressByIdResponse
        {
            Data = new ServiceAddressDto
            {
                Id = serviceAddress.Id,
                CustomerId = serviceAddress.CustomerId,
                ServiceAddressName = serviceAddress.ServiceAddressName,
                ServiceAddressType = serviceAddress.ServiceAddressType,
                Address = serviceAddress.Address,
                City = serviceAddress.City,
                State = serviceAddress.State,
                Zip = serviceAddress.Zip,
                ContactName = serviceAddress.ContactName,
                ContactPhone = serviceAddress.ContactPhone,
                ContactEmail = serviceAddress.ContactEmail,
                IsActive = serviceAddress.IsActive,
                CreatedAt = serviceAddress.CreatedAt,
                ModifiedAt = serviceAddress.ModifiedAt
            }
        };
    }
}
