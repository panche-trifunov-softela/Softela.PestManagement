using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories
{
    public interface ISiteRepository
    {
        Task<Site?> GetByIdAsync(int id);
        Task<List<Site>> GetByAccountIdAsync(int accountId);
        Task<List<Site>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
        Task<int> UpsertAsync(Site site);
        Task DeleteAsync(int id);
    }
}
