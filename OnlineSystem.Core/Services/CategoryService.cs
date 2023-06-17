using Microsoft.EntityFrameworkCore;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.IRepositories;

namespace OnlineSystem.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<List<Category>> getCategoriesByIds(List<int> Ids)
    {
        if (Ids is null || !Ids.Any())
            return new List<Category>();
        
        return await _categoryRepository.Find(c => Ids.Contains(c.Id)).ToListAsync();
    }
}