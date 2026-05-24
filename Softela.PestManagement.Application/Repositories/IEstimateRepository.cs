using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IEstimateRepository
{
    Task<int> CreateAsync(Estimate estimate);
    Task<int> UpdateAsync(Estimate estimate);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<List<Estimate>> GetByServiceAddressIdAsync(int serviceAddressId, int tenantId);
}
