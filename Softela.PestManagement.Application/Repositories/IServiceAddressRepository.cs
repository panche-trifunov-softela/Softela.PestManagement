using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IServiceAddressRepository
{
    Task<int> CreateAsync(ServiceAddress serviceAddress);
    Task UpdateAsync(ServiceAddress serviceAddress);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<ServiceAddress> GetByIdAsync(int id, int tenantId);
    Task<List<ServiceAddress>> GetByCustomerIdAsync(int customerId, int tenantId);
}
