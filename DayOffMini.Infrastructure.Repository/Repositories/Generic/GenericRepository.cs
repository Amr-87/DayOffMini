using DayOffMini.Domain.Interfaces;
using DayOffMini.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DayOffMini.Infrastructure.Repository.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
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

        public void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity!);
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int entityId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == entityId);
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
