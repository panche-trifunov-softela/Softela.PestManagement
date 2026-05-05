using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ITenantRepository
{
    Task<int> UpsertAsync(Tenant tenant);
    Task<List<Tenant>> GetAllAsync();
    Task<Tenant> GetByIdAsync(int id);
}
