using FluentValidation;
using Mttechne.Backend.Junior.Domain.Entidades;

namespace Mttechne.Backend.Junior.Services.Model.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(f => f.Nome)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
           .Length(3, 100)
           .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}