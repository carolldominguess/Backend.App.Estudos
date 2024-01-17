using FluentValidation;
using Mttechne.Backend.Junior.Domain.Entidades;

namespace Mttechne.Backend.Junior.Services.Model.Validations
{
    public class ProdutoBuscaValidation : AbstractValidator<Produto>
    {
        public ProdutoBuscaValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .Matches("^[a-zA-ZÀ-ÖØ-öø-ÿ0-9 ]+$").WithMessage("O campo {PropertyName} não pode conter caracteres especiais.");
        }
    }
}
