using System.Linq.Expressions;
using OnlineSystem.Core.IRepositories;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Data.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly OnlineSystemDbContext _onlineSystemDbContext;

    public Repository(OnlineSystemDbContext onlineSystemDbContext)
    {
        _onlineSystemDbContext = onlineSystemDbContext;
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _onlineSystemDbContext.Set<TEntity>().Where(predicate);
    }
    
    public async Task AddAsync(TEntity entity)
    {
       await _onlineSystemDbContext.Set<TEntity>().AddAsync(entity);
       await _onlineSystemDbContext.SaveChangesAsync();
    }
    
    public async Task Remove(TEntity entity)
    {
        _onlineSystemDbContext.Set<TEntity>().Remove(entity);
        await _onlineSystemDbContext.SaveChangesAsync();
    }
    
    public async Task Update(TEntity entity)
    {
        _onlineSystemDbContext.Set<TEntity>().Update(entity);
        await _onlineSystemDbContext.SaveChangesAsync();
    }
    
    public IEnumerable<TEntity> Pagenate(PaginationFilter filter, Expression<Func<TEntity, bool>> predicate)
    {
        var itemQuery = Find(predicate);
        var items = itemQuery.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();
        
        return items;
    }
}