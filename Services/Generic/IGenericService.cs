namespace DayOffMini.Services.Generic
{
    public interface IGenericService<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);

        Task DeleteAsync(int entityId);
        Task<T?> GetByIdAsync(int entityId);
        Task<ICollection<T>> GetAllAsync();
    }
}
