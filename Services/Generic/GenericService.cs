
using DayOffMini.Repositories.Generic;

namespace DayOffMini.Services.Generic
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task CreateAsync(T entity)
        {
            await _genericRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int entityId)
        {
            await _genericRepository.DeleteAsync(entityId);
        }


        public async Task UpdateAsync(T entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(int entityId)
        {
            return await _genericRepository.GetByIdAsync(entityId);
        }
    }
}
