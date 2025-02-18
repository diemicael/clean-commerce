using CleanCommerce.Application.DTOs;
using CleanCommerce.Application.Orders.Commands;

namespace CleanCommerce.Application.Common.Interfaces;

public interface IOrderService
{
    Task<OrderDto> ProcessOrder(CreateOrderCommand command);
}