using System.Linq.Expressions;

namespace MyTodo.Api.Domin.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetListAsync(int pageNum, int pageSize, Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}