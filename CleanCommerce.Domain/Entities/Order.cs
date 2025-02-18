using CleanCommerce.Domain.Enums;

namespace CleanCommerce.Domain.Entities;

public class Order
{
    public int Id { get; private set; }
    public DateTime OrderDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public int ProductId { get; private set; }
    public virtual Product Product { get; private set; }
    public int Quantity { get; private set; }

    public Order(decimal totalAmount, int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
        TotalAmount = totalAmount;
        OrderDate = DateTime.UtcNow;
        Status = OrderStatus.PENDING;
    }

    public void Approve()
    {
        if (Status != OrderStatus.PENDING)
            throw new InvalidOperationException("Pedido não está pendente");

        Status = OrderStatus.CONFIRMED;
    }

    public void Cancel()
    {
        if (Status != OrderStatus.PENDING)
            throw new InvalidOperationException("Apenas produtos pendentes podem ser cancelados.");
        
        Status = OrderStatus.CANCELLED;
    }
}