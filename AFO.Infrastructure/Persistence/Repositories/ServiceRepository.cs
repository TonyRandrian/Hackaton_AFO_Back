using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository(AfoDbContext context) : IServiceRepository
    {

        public async Task AddAsync(Service service)
        {
            await context.Services.AddAsync(service);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Service service)
        {
            context.Services.Remove(service);
            await context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return context.Services.AnyAsync(s => s.Id == id);
        }

        public Task<List<Service>> GetAllAsync()
        {
            return context.Services
                .Include(s => s.Contents)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public Task<Service?> GetByIdAsync(Guid id)
        {
            return context.Services
                .AsNoTracking()
                .Include(s => s.Realizations)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Service service)
        {
            context.Services.Update(service);
            await context.SaveChangesAsync();
        }
    }
}
