
using DayOffMini.Data.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await _dbSet.FindAsync(entityId);
            if (entity == null)
                throw new KeyNotFoundException();

            _dbSet.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

    }
}
