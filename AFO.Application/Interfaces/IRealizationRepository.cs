using AFO.Domain.Entities;
namespace AFO.Application.Interfaces;

public interface IRealizationRepository
{
    Task AddAsync(Realization realization,CancellationToken cancellationToken = default);
    Task<List<Realization>> GetAllAsync(bool publicOnly = false,CancellationToken cancellationToken = default);
    Task<Realization?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    //Utiliser pour verifier l'appartenance du contenu avant la cration ou la modif 
    Task<bool> VerifyServiceContentToServiceAsync(Guid serviceId,Guid serviceContentId,CancellationToken cancellationToken = default);
    Task UpdateAsync(Realization realization, CancellationToken cancellationToken = default);
    Task DeleteAsync( Realization realization, CancellationToken cancellationToken = default);
}
