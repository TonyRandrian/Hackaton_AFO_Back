
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories;

public class AdvantageRepository(AfoDbContext context) : IAdvantageRepository
{
    public Task<List<Advantage>> GetAllAsync()
    {
        return context.Advantages
            .AsNoTracking()
            .OrderBy(a => a.Name)
            .ToListAsync();
    }

    public Task<Advantage?> GetByIdAsync(Guid id)
    {
        return context.Advantages.FirstOrDefaultAsync(a => a.Id == id);
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return context.Advantages.AnyAsync(a => a.Id == id);
    }

    public Task<bool> IsUsedAsync(Guid id)
    {
        return context.RealizationAdvantages.AnyAsync(ra => ra.AdvantageId == id);
    }

    public async Task AddAsync(Advantage advantage)
    {
        await context.Advantages.AddAsync(advantage);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Advantage advantage)
    {
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Advantage advantage)
    {
        context.Advantages.Remove(advantage);
        await context.SaveChangesAsync();
    }
}
