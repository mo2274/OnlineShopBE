using Microsoft.AspNetCore.Http;
using OnlineSystem.Core.Dtos;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Core.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetProductsData(PaginationFilter paginationFilter);
    Task AddNewProduct(Product product, IFormFile? imageFile);
    Task<Product> GetProductById(int id);
    Task RemoveProduct(Product product);
}