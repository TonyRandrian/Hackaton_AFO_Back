using AFO.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository(AfoDbContext context) : IServiceRepository
    {
        public Task<bool> ExistsAsync(Guid id)
        {
            return context.Services.AnyAsync(s => s.Id == id);
        }
    }
}
