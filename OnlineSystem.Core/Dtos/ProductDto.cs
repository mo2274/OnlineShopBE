namespace OnlineSystem.Core.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameAr { get; set; }
    
    public decimal Price { get; set; }
    
    public string ImageURL { get; set; }
    
    public IList<CategoryDto> Categories { get; set; }
}