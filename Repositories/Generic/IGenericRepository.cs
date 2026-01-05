using DayOffMini.Data.Interfaces;

namespace DayOffMini.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(int entityId);
        Task<T?> GetByIdAsync(int entityId);
        Task<ICollection<T>> GetAllAsync();
    }
}
