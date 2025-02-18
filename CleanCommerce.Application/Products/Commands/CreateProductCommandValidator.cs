using FluentValidation;

namespace CleanCommerce.Application.Products.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .Length(2, 100).WithMessage("Nome não pode ter mais que 100 caracteres");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Preço deve ser maior que zero");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantidade em estoque não pode ser negativa");
    }
}