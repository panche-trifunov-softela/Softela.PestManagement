using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IProgramRepository
{
    Task<int> CreateAsync(Program program);
    Task<int> UpdateAsync(Program program);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<Program?> GetByIdAsync(int id, int tenantId);
    Task<List<Program>> GetByEstimateIdAsync(int estimateId, int tenantId);
}
