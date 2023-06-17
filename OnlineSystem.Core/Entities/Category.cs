using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSystem.Core.Entities;

public class Category : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    public DateTime? CreatedDate { get; set; }

    [ForeignKey(nameof(ParentCategory))]
    public int? ParentCategoryId { get; set; }

    public Category ParentCategory { get; set; }
    
    public ICollection<Category> SubCategories { get; set; }

    public ICollection<Product> Products { get; set; }
}