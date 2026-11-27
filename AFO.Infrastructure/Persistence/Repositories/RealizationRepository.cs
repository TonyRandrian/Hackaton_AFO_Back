
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFO.Infrastructure.Persistence.Repositories;

public class RealizationRepository(AfoDbContext context): IRealizationRepository
{
    public async Task AddAsync(Realization realization,CancellationToken cancellationToken = default)
    {
        await context.Realizations.AddAsync(realization, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<Realization>> GetAllAsync(bool publicOnly = false,CancellationToken cancellationToken = default)
    {
        IQueryable<Realization> query = context.Realizations.AsNoTracking();
        if (publicOnly)
        {
            query = query.Where(r => r.IsPublic);
        }
        return await query.OrderBy(r => r.Name).ToListAsync(cancellationToken);
    }

    public Task<Realization?> GetByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        //Include() sy ThznInclude() : recuperation des données liées
        return context.Realizations
            .Include(r => r.Service)
            .Include(r => r.ServiceContent)
            .Include(r => r.Images)
                .ThenInclude(i => i.RealizationImageType)
            .Include(r => r.RealizationAdvantages)
                .ThenInclude(ra => ra.Advantage)
            .Include(r => r.RealizationTechnologies)
                .ThenInclude(rt => rt.Technology)
            .Include(r => r.RealizationProcessus)
                .ThenInclude(rp => rp.Processus)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public Task<bool> VerifyServiceContentToServiceAsync(Guid serviceId, Guid serviceContentId,CancellationToken cancellationToken = default)
    {
        return context.ServiceContents.AnyAsync(
            sc => sc.Id == serviceContentId &&sc.ServiceId == serviceId,
            cancellationToken);
    }

    public async Task UpdateAsync(Realization realization,CancellationToken cancellationToken = default)
    {
        context.Realizations.Update(realization);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync( Realization realization, CancellationToken cancellationToken = default)
    {
        context.Realizations.Remove(realization);
        await context.SaveChangesAsync(cancellationToken);
    }
}
