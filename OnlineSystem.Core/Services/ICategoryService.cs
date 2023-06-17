using OnlineSystem.Core.Entities;

namespace OnlineSystem.Core.Services;

public interface ICategoryService
{
    Task<List<Category>> getCategoriesByIds(List<int> Ids);
}