using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories
{
    public class ServiceContentRepository(AfoDbContext context)
        : IServiceContentRepository
    {

        public async Task AddAsync(ServiceContent serviceContent)
        {
            await context.ServiceContents.AddAsync(serviceContent);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceContent serviceContent)
        {
            context.ServiceContents.Remove(serviceContent);
            await context.SaveChangesAsync();
        }

        public Task<ServiceContent?> GetByIdAsync(Guid id)
        {
            return context.ServiceContents
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public Task<List<ServiceContent>> GetByServiceIdAsync(Guid serviceId)
        {
            return context.ServiceContents
                .Where(sc => sc.ServiceId == serviceId)
                .ToListAsync();
        }

        public Task<bool> HasRealizationAsync(Guid id)
        {
            return context.Realizations.AnyAsync(r => r.ServiceContentId == id);
        }

        public async Task UpdateAsync(ServiceContent serviceContent)
        {
            context.ServiceContents.Update(serviceContent);
            await context.SaveChangesAsync();
        }
    }
}
