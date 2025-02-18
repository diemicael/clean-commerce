using System.Text.Json.Serialization;

namespace CleanCommerce.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public bool IsActive { get; private set; }
    public virtual ICollection<Order> Orders { get; set; }
    
    public Product() { }
    
    [JsonConstructor]
    public Product(string name, decimal price, int stockQuantity, bool isActive, ICollection<Order> orders)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
        IsActive = isActive;
        Orders = orders;
    }

    public Product(string name, decimal price, int stockQuantity)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
        IsActive = true;
    }

    public void UpdateStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantidade não pode ser negativa.");
        
        StockQuantity = quantity;
    }

    public void DeductStock(int quantity)
    {
        if (quantity > StockQuantity)
            throw new InvalidOperationException("Estoque Insuficiente.");
        
        StockQuantity -= quantity;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Preço deve ser maior que zero.");
        
        Price = newPrice;
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("Produto já está inativo.");
        
        IsActive = false;
    }
}