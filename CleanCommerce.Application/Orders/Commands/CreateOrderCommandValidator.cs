using FluentValidation;

namespace CleanCommerce.Application.Orders.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ID do produto inválido");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero");
    }
}