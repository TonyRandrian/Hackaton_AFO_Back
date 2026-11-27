
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories
{
    public class RealizationImageRepository(AfoDbContext context)
        : IRealizationImageRepository
    {
        public async Task<List<RealizationImage>> GetByRealizationIdAsync(
            Guid realizationId)
        {
            return await context.RealizationImages
                .Include(i => i.RealizationImageType)
                .Where(i => i.RealizationId == realizationId)
                .ToListAsync();
        }

        public Task<RealizationImage?> GetByIdAsync(Guid id)
        {
            return context.RealizationImages
                .Include(i => i.RealizationImageType)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> RealizationExistsAsync(Guid realizationId)
        {
            return context.Realizations
                .AnyAsync(r => r.Id == realizationId);
        }

        public Task<bool> ImageTypeExistsAsync(Guid typeId)
        {
            return context.RealizationImageTypes
                .AnyAsync(t => t.Id == typeId);
        }

        public async Task AddAsync(RealizationImage image)
        {
            await context.RealizationImages.AddAsync(image);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RealizationImage image)
        {
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RealizationImage image)
        {
            context.RealizationImages.Remove(image);
            await context.SaveChangesAsync();
        }
    }
}
