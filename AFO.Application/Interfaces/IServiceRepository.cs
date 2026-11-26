namespace AFO.Application.Interfaces
{
    public interface IServiceRepository
    {
        Task<bool> ExistsAsync(Guid id);
    }
}
