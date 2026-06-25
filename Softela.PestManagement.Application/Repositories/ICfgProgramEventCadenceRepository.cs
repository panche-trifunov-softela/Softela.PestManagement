using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgProgramEventCadenceRepository
{
    Task<int> CreateAsync(CfgProgramEventCadence cfgProgramEventCadence);
    Task<int> UpdateAsync(CfgProgramEventCadence cfgProgramEventCadence);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgProgramEventCadence?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgProgramEventCadence>> GetByProgramIdAsync(int cfgProgramId, int tenantId);
}
