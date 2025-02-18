using AutoMapper;
using CleanCommerce.Application.Common.Interfaces;
using MediatR;

namespace CleanCommerce.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<int>
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }


    public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderDto = await _orderService.ProcessOrder(command);
        return orderDto.Id;
    }
}