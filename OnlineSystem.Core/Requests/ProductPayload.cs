using Microsoft.AspNetCore.Http;

namespace OnlineSystem.Core.Requests;

public class ProductPayload
{
    public string Name { get; set; }
    public string NameAr { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool HasAvailableStock { get; set; }
    
    public IFormFile? Image { get; set; }
    public List<int> Categories { get; set; }

}