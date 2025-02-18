using AutoMapper;
using CleanCommerce.Application.Common.Interfaces;
using CleanCommerce.Application.DTOs;
using CleanCommerce.Application.Orders.Commands;
using CleanCommerce.Domain.Abstractions;
using CleanCommerce.Domain.Entities;
using CleanCommerce.Domain.Enums;

namespace CleanCommerce.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<OrderDto> ProcessOrder(CreateOrderCommand command)
    {
        // Validação inicial
        if (!await ValidateOrderCreation(command.ProductId, command.Quantity))
            throw new InvalidOperationException("Pedido Inválido.");
        
        // Cálculo do valor
        var totalAmount = await CalculateOrderAmount(command.ProductId, command.Quantity);
        
        // Criação do pedido
        var order = new Order(totalAmount, command.ProductId, command.Quantity);
        
        // Atualização do estoque
        var product = await _productRepository.GetById(command.ProductId);
        product.DeductStock(command.Quantity);
        
        // Persistência das alterações
        await _orderRepository.Add(order);
        await _productRepository.Update(product);
        
        return _mapper.Map<OrderDto>(order);
    }

    private async Task<bool> ValidateOrderCreation(int productId, int quantity)
    {
        var product = await _productRepository.GetById(productId);
        
        // Regras de validação do pedido
        if (product is null) return false;
        if (!product.IsActive) return false;
        if (product.StockQuantity < quantity) return false;

        return true;
    }

    private async Task<decimal> CalculateOrderAmount(int productId, int quantity)
    {
        var product = await _productRepository.GetById(productId);
        
        if (product is null) 
            throw new ArgumentException("Produto não encontrado.");
        
        // Regras de cálculo do valor do pedido
        decimal baseAmount = product.Price * quantity;
        
        // Aplicação de desconto por quantidade
        if (quantity >= 10)
            baseAmount *= 0.9m; // 10% de desconto
        else if (quantity >= 5)
            baseAmount *= 0.95m; // 5% de desconto
        
        return baseAmount;
    }
}