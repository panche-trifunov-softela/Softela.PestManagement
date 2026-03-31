using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICustomerContactRepository
{
    Task<int> UpsertAsync(CustomerContact contact);
    Task<List<CustomerContact>> GetByCustomerIdAsync(int customerId, int tenantId);
    Task<int> UpsertPhoneAsync(CustomerContactPhone phone);
    Task<List<CustomerContactPhone>> GetPhonesByContactIdAsync(int contactId, int tenantId);
    Task DeletePhonesByContactIdAsync(int contactId, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
}
