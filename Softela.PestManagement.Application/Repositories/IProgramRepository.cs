using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IProgramRepository
{
    Task<int> CreateAsync(OpsProgram program);
    Task<int> UpdateAsync(OpsProgram program);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<OpsProgram?> GetByIdAsync(int id, int tenantId);
    Task<List<OpsProgram>> GetByEstimateIdAsync(int estimateId, int tenantId);
}
