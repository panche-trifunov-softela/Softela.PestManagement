using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.ServiceAddress.DeleteServiceAddress;

public class DeleteServiceAddressHandler : IRequestHandler<DeleteServiceAddressRequest, bool>
{
    private readonly IServiceAddressRepository _serviceAddressRepository;
    private readonly ITenantContext _tenantContext;

    public DeleteServiceAddressHandler(IServiceAddressRepository serviceAddressRepository, ITenantContext tenantContext)
    {
        _serviceAddressRepository = serviceAddressRepository;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(DeleteServiceAddressRequest request, CancellationToken cancellationToken)
    {
        await _serviceAddressRepository.DeleteAsync(request.Id, _tenantContext.TenantId);
        return true;
    }
}
