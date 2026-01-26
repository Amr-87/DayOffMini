using System.Linq.Expressions;

namespace DayOffMini.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetByIdAsync(int entityId, params Expression<Func<T, object>>[] includes);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
              Expression<Func<T, object>>? orderBy = null,
                                     bool ascending = true,
          params Expression<Func<T, object>>[] includes);
    }
}
