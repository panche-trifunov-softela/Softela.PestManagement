using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IEstimateRepository
{
    Task<int> CreateAsync(OpsEstimate estimate);
    Task<int> UpdateAsync(OpsEstimate estimate);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<List<OpsEstimate>> GetByServiceAddressIdAsync(int serviceAddressId, int tenantId);
}
