using OnlineSystem.Core.Entities;

namespace OnlineSystem.Core.Dtos;

public class CategoryDto
{
    public string Name { get; set; }

    public string ParentCategoryName { get; set; }
}