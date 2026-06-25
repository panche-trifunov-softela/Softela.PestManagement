using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgProgramRepository
{
    Task<int> CreateAsync(CfgProgram cfgProgram);
    Task<int> UpdateAsync(CfgProgram cfgProgram);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgProgram?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgProgram>> GetByTenantIdAsync(int tenantId);
}
