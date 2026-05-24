using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICustomerRepository
{
    Task<int> CreateAsync(Customer customer);
    Task<int> UpdateAsync(Customer customer);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<Customer> GetByIdAsync(int id, int tenantId);
    Task<List<Customer>> GetByTenantIdAsync(int tenantId);
}
