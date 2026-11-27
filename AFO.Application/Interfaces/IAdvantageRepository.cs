
using AFO.Domain.Entities;

namespace AFO.Application.Interfaces;

public interface IAdvantageRepository
{
    Task<List<Advantage>> GetAllAsync();
    Task<Advantage?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<bool> IsUsedAsync(Guid id);
    Task AddAsync(Advantage advantage);
    Task UpdateAsync(Advantage advantage);
    Task DeleteAsync(Advantage advantage);
}
