using System.ComponentModel.DataAnnotations;

namespace OnlineSystem.Core.Entities;

public class Product : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(100)]
    public string NameAr { get; set; }
    
    [Required]
    [StringLength(300)]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    public bool HasAvailableStock { get; set; }

    public string ImageUrl { get; set; }

    public ICollection<Category> Categories { get; set; }
}