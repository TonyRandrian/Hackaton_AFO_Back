using AFO.Domain.Entities;

namespace AFO.Application.Interfaces
{
    public interface IServiceContentRepository
    {
        Task<List<ServiceContent>> GetByServiceIdAsync(Guid serviceId);
        Task<ServiceContent?> GetByIdAsync(Guid id);
        Task AddAsync(ServiceContent serviceContent);
        Task UpdateAsync(ServiceContent serviceContent);
        Task DeleteAsync(ServiceContent serviceContent);

    }
}
