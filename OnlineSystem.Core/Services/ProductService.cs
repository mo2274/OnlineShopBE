using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineSystem.Core.Dtos;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.IRepositories;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IWebHostEnvironment _environment;

    public ProductService(IProductRepository productRepository, IWebHostEnvironment environment)
    {
        _productRepository = productRepository;
        _environment = environment;
    }
    
    public Task<List<ProductDto>> GetProductsData(PaginationFilter paginationFilter)
    {
        return _productRepository.GetProductsData(paginationFilter);
    }

    public async Task AddNewProduct(Product product, IFormFile? imageFile)
    {
        if (imageFile is not null && imageFile.Length > 0)
        {
            if (!Directory.Exists(_environment.WebRootPath + "\\ProductImages")) {
                Directory.CreateDirectory(_environment.WebRootPath + "\\ProductImages\\");
            }

            await using(FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\ProductImages\\" + imageFile.FileName)) 
            {
                await imageFile.CopyToAsync(filestream);
                filestream.Flush();
            }

            product.ImageUrl = "\\ProductImages\\" + imageFile.FileName;
        }
        
        await _productRepository.AddAsync(product);
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _productRepository.Find(p => p.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task RemoveProduct(Product product)
    { 
       await _productRepository.Remove(product);
    }
}