using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineSystem.Core.Entities;
using OnlineSystem.Data.EntitiesConfiguration;

namespace OnlineSystem.Data;

public class OnlineSystemDbContext : DbContext
{
    public OnlineSystemDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}