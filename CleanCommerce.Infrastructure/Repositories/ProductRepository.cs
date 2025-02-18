using CleanCommerce.Domain.Abstractions;
using CleanCommerce.Domain.Entities;
using CleanCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCommerce.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
        => await _context.Products.ToListAsync();

    public async Task<Product?> GetById(int id)
        => await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<int> Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var product = await GetById(id);
        
        if (product is null)
            throw new InvalidOperationException("Produto não encontrado.");
        
        _context.Products.Remove(product);
        return product.Id;
    }
}