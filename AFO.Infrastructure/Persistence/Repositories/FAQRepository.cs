using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories
{
    public class FAQRepository(AfoDbContext context) : IFAQRepository
    {
        public async Task AddAsync(FAQ faq)
        {
            await context.FAQs.AddAsync(faq);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FAQ faq)
        {
            context.FAQs.Remove(faq);
            await context.SaveChangesAsync();
        }

        public Task<FAQ?> GetByIdAsync(Guid id)
        {
            return context.FAQs.FirstOrDefaultAsync(f => f.Id == id);
        }

        public Task<List<FAQ>> GetByServiceIdAsync(Guid serviceId)
        {
            return context.FAQs
                .AsNoTracking()
                .Where(f => f.ServiceId == serviceId)
                .OrderBy(f => f.Question)
                .ToListAsync();
        }

        public async Task UpdateAsync(FAQ faq)
        {
            context.FAQs.Update(faq);
            await context.SaveChangesAsync();
        }
    }
}
