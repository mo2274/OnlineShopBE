using OnlineSystem.Core.Entities;
using OnlineSystem.Core.IRepositories;
using OnlineSystem.Data.Repositories.Base;

namespace OnlineSystem.Data.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(OnlineSystemDbContext onlineSystemDbContext) : base(onlineSystemDbContext)
    {
    }
}