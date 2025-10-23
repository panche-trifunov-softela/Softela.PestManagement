using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories
{
    public interface ISiteRepository
    {
        Task<int> UpsertAsync(Site site);
        Task<Site?> GetByIdAsync(int id);
        Task<Site?> GetByReferenceNumberAsync(string referenceNumber);
        Task<IEnumerable<Site>> GetAllAsync();
        Task<IEnumerable<Site>> GetByAccountIdAsync(int accountId);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ReferenceNumberExistsAsync(string referenceNumber, int? excludeId = null);
    }
}
