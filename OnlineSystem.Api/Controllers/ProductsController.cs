using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSystem.Core.Dtos;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.Requests;
using OnlineSystem.Core.Services;

namespace OnlineSystem.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
//[Authorize(Roles = "adm6in")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;
    private readonly IValidator<PaginationFilter> _filterValidator;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductPayload> _productPayloadValidator;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ILogger<ProductsController> logger, 
        IValidator<PaginationFilter> filterValidator, IMapper mapper, IValidator<ProductPayload> productPayloadValidator,
        ICategoryService categoryService)
    {
        _productService = productService;
        _logger = logger;
        _filterValidator = filterValidator;
        _mapper = mapper;
        _productPayloadValidator = productPayloadValidator;
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(statusCode:StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductsData([FromQuery] int pageNumber, int pageSize)
    {
        var paginationFilter = new PaginationFilter()
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
       var validationResult = await _filterValidator.ValidateAsync(paginationFilter);
       
       if (!validationResult.IsValid)
       {
           _logger.LogInformation($"Validation Error: Page Number = {paginationFilter.PageNumber}, PageSize = {paginationFilter.PageSize}");
           return BadRequest(
               validationResult.Errors.Select(i => i.ErrorCode).ToList());
       }

       return Ok(await _productService.GetProductsData(paginationFilter));
    }

    [HttpPost]
    public async Task<IActionResult> AddNewProduct([FromForm] ProductPayload productPayload)
    {
        var validationResult = await _productPayloadValidator.ValidateAsync(productPayload);
       
        if (!validationResult.IsValid)
        {
            return BadRequest(
                validationResult.Errors.Select(i => i.ErrorCode).ToList());
        }
        
        var product = _mapper.Map<Product>(productPayload);

        product.Categories = await _categoryService.getCategoriesByIds(productPayload.Categories);
        
        await _productService.AddNewProduct(product, productPayload.Image);
        
        return Ok("Product Added successfully");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productService.GetProductById(id);

        if (product is null)
            return BadRequest("Product does not exist");

        await _productService.RemoveProduct(product);
        
        return Ok("Product deleted successfully");
    }
}