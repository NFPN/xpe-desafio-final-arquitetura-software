using FluentValidation;
using VendasOnline.Dominio.DTOs;

namespace VendasOnline.API.Validadores
{
    public class ProdutoValidator : AbstractValidator<ProdutoDto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório")
                .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres");

            RuleFor(p => p.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero");

            RuleFor(p => p.QuantidadeEstoque)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa");
        }
    }
}
