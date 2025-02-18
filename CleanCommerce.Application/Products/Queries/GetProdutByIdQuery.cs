using AutoMapper;
using CleanCommerce.Application.DTOs;
using CleanCommerce.Domain.Abstractions;
using MediatR;

namespace CleanCommerce.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(request.Id);

        if (product is null)
            throw new InvalidOperationException("Produto não encontrado.");

        return _mapper.Map<ProductDto>(product);
    }
}