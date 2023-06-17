using System.Linq.Expressions;

namespace OnlineSystem.Core.IRepositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task Remove(TEntity entity);
    Task Update(TEntity entity);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
}