using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgRouteRepository
{
    Task<int> CreateAsync(CfgRoute cfgRoute);
    Task<int> UpdateAsync(CfgRoute cfgRoute);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgRoute?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgRoute>> GetByEmployeeIdAsync(int cfgEmployeeId, int tenantId);
}
