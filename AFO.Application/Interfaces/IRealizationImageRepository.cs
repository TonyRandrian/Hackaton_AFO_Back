
using AFO.Domain.Entities;

namespace AFO.Application.Interfaces
{
    public interface IRealizationImageRepository
    {
        Task<List<RealizationImage>> GetByRealizationIdAsync(Guid realizationId);

        Task<RealizationImage?> GetByIdAsync(Guid id);

        Task<bool> RealizationExistsAsync(Guid realizationId);

        Task<bool> ImageTypeExistsAsync(Guid typeId);

        Task AddAsync(RealizationImage image);

        Task UpdateAsync(RealizationImage image);

        Task DeleteAsync(RealizationImage image);
    }
}
