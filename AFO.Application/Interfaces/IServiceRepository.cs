using AFO.Domain.Entities;

namespace AFO.Application.Interfaces
{
    public interface IServiceRepository
    {
        Task<bool> ExistsAsync(Guid id);
        Task<List<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(Guid id);
        Task AddAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(Service service);
    }
}
