using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineSystem.Core.Dtos;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.IRepositories;
using OnlineSystem.Core.Requests;
using OnlineSystem.Data.Repositories.Base;

namespace OnlineSystem.Data.Repositories;

public class ProductRepository : Repository<Product> , IProductRepository
{
    private readonly OnlineSystemDbContext _onlineSystemDbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public string _baseUrl { get; set; }

    public ProductRepository(OnlineSystemDbContext onlineSystemDbContext, IHttpContextAccessor  httpContextAccessor) : base(onlineSystemDbContext)
    {
        _onlineSystemDbContext = onlineSystemDbContext;
        _httpContextAccessor = httpContextAccessor;
        _baseUrl =
            $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}";
    }

    public async Task<List<ProductDto>> GetProductsData(PaginationFilter paginationFilter)
    {
        var queryable = _onlineSystemDbContext
            .Products
            .Include(p => p.Categories)
            .ThenInclude(c => c.ParentCategory)
            .Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                NameAr = p.NameAr,
                Price = p.Price,
                ImageURL = $"{_baseUrl}{p.ImageUrl}",
                Categories = p.Categories
                    .Select(c => new CategoryDto()
                    {
                        Name = c.Name,
                        ParentCategoryName = c.ParentCategory.Name
                    }).ToList()
            })
            .OrderBy(p => p.Name);
        
        var result = await queryable.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
            .Take(paginationFilter.PageSize)
            .ToListAsync();

        return result;
    }
}