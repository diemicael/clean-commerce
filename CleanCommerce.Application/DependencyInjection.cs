using System.Reflection;
using CleanCommerce.Application.Common.Behaviours;
using CleanCommerce.Application.Common.Interfaces;
using CleanCommerce.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        
        // Validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        // Services
        services.AddScoped<IOrderService, OrderService>();
        
        return services;
    }
}