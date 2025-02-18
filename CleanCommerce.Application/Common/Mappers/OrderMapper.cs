using AutoMapper;
using CleanCommerce.Application.DTOs;
using CleanCommerce.Application.Orders.Commands;
using CleanCommerce.Domain.Entities;

namespace CleanCommerce.Application.Common.Mappers;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<CreateOrderCommand, Order>();
    }
}