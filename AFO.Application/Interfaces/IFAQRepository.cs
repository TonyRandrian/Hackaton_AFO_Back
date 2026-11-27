using AFO.Domain.Entities;

namespace AFO.Application.Interfaces
{
    public interface IFAQRepository
    {
        Task<List<FAQ>> GetByServiceIdAsync(Guid serviceId);
        Task<FAQ?> GetByIdAsync(Guid id);
        Task AddAsync(FAQ faq);
        Task UpdateAsync(FAQ faq);
        Task DeleteAsync(FAQ faq);
    }
}