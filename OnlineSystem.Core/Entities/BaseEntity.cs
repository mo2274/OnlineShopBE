using System.ComponentModel.DataAnnotations;

namespace OnlineSystem.Core.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}