using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IEstimateRepository
{
    Task<int> CreateAsync(Estimate estimate);
    Task UpdateAsync(Estimate estimate);
    Task DeleteAsync(int id, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<List<Estimate>> GetByServiceAddressIdAsync(int serviceAddressId, int tenantId);
}
