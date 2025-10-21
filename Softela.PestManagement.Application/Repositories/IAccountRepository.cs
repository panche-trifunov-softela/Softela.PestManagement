using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<int> CreateAsync(Account account);
        Task<Account?> GetByIdAsync(int id);
        Task<Account?> GetByAccountNumAsync(string accountNum);
        Task<IEnumerable<Account>> GetAllAsync(int companyId);
        Task<IEnumerable<Account>> SearchAsync(int companyId, string? searchTerm, short? isActive);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> AccountNumExistsAsync(string accountNum, int companyId, int? excludeId = null);
    }
}
