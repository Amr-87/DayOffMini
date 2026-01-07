using System.Linq.Expressions;

namespace DayOffMini.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int entityId);
        //Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    }
}
