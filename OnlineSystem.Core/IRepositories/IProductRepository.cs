using OnlineSystem.Core.Dtos;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Core.IRepositories;

public interface IProductRepository : IRepository<Product>
{
    Task<List<ProductDto>> GetProductsData(PaginationFilter paginationFilter);
}