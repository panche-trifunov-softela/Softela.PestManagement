using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(int id);
        Task<Account?> GetByAccountNumAsync(string accountNum);
        Task<List<Account>> GetAllAsync(int companyId);
        Task<List<Account>> SearchAsync(int companyId, string? searchTerm, short? isActive);
        Task<bool> ExistsAsync(int id);
        Task<bool> AccountNumExistsAsync(string accountNum, int companyId, int? excludeId);
        Task<int> UpsertAsync(Account account);
        Task DeleteAsync(int id);
    }
}
