using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; } = 0;
        public decimal MetaMensal { get; set; } = 0;

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo Nome não pode ser nulo");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo Email não pode ser nulo").EmailAddress();

            RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo Telefone não pode ser nulo").MinimumLength(11).WithMessage("Telefone precisa conter 11 dígitos");

            RuleFor(x => x.DataNascimento).NotNull().WithMessage("O campo Data Nascimento não pode ser nulo")
                .LessThan(DateTime.Now.AddYears(-16)).WithMessage("A idade mínima é 16 anos");

            RuleFor(x => x.Endereco).NotEmpty().WithMessage("O campo Endereço é obrigátório");

            RuleFor(x => x.DataContratacao).NotNull().WithMessage("O campo Data de Contratação é obrigatória")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode estar no futuro");

            RuleFor(x => x.ComissaoPercentual).NotNull().WithMessage("O campo Comissão Percentual é obrigatória").GreaterThan(0).WithMessage("A Comissão Percentual não pode ser negativa e nem igual a 0");

            RuleFor(x => x.MetaMensal).NotNull().WithMessage("O campo Meta Mensal é obrigatória").GreaterThan(0).WithMessage("A Meta Mensal não pode ser negativa e nem igual a 0");
        }
    }
}
