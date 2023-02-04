using MyTodo.Api.Infratructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNum, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            int currentPage = pageNum + 1;

            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(predicate).Skip(currentPage * pageSize).Take(pageSize);

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbContext.AddAsync(entity);
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}