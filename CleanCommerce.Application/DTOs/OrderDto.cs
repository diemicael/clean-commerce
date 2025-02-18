using CleanCommerce.Domain.Enums;

namespace CleanCommerce.Application.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}