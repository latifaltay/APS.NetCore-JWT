using System.Linq.Expressions;

namespace AuthServerForJWT_Edu.Core.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Remove(TEntity entity);
    TEntity Update(TEntity entity);
}