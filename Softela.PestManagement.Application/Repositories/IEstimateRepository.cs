using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface IEstimateRepository
{
    Task<int> CreateAsync(Estimate estimate);
    Task UpdateAsync(Estimate estimate);
}
