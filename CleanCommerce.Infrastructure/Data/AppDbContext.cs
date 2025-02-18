using CleanCommerce.Domain.Entities;
using CleanCommerce.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CleanCommerce.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
    }
}