using AutoMapper;
using CleanCommerce.Domain.Abstractions;
using CleanCommerce.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CleanCommerce.Application.Products.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    //private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper /*IValidator<CreateProductCommand> validator*/)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        //_validator = validator;
    }

    public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // _validator.ValidateAndThrow(command); // não mais necessário após adicionar o arquivo ValidationBehaviour
        
        var newProduct = new Product(command.Name, command.Price, command.StockQuantity);

        await _productRepository.Add(newProduct);
        return newProduct.Id;
    }
}