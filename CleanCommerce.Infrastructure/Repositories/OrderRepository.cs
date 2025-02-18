using CleanCommerce.Domain.Abstractions;
using CleanCommerce.Domain.Entities;
using CleanCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCommerce.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAll()
        => await _context.Orders.ToListAsync();

    public async Task<Order?> GetById(int id)
        => await _context.Orders
            .Include(o => o.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    
    public async Task<int> Add(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order.Id;
    }

    public async Task Update(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var order = await GetById(id);
        
        if (order is null)
            throw new InvalidOperationException("Pedido não encontrado.");
        
        _context.Orders.Remove(order);
        return order.Id;
    }
}