using AutoMapper;
using CleanCommerce.Application.DTOs;
using CleanCommerce.Application.Products.Commands;
using CleanCommerce.Domain.Entities;

namespace CleanCommerce.Application.Common.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDto>();
        CreateProjection<CreateProductCommand, Product>();
    }
}