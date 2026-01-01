namespace DayOffMini.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        Task DeleteAsync(int entityId);
        Task<T?> GetByIdAsync(int entityId);
        Task<ICollection<T>> GetAllAsync();
    }
}
