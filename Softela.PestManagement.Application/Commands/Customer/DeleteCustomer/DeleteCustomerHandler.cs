using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Commands.Customer.DeleteCustomer;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ITenantContext _tenantContext;

    public DeleteCustomerHandler(ICustomerRepository customerRepository, ITenantContext tenantContext)
    {
        _customerRepository = customerRepository;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteAsync(request.Id, _tenantContext.TenantId);
        return true;
    }
}
