using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }
    
    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo nome não pode ser nulo");

            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("O campo CNPJ não pode ser nulo").MinimumLength(14).WithMessage("O CNPJ precisa conter 14 dígitos");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo Email não pode ser nulo").EmailAddress();

            RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo Telefone não pode ser nulo").MinimumLength(11).WithMessage("O Telefone contém apenas 11 dígitos");

            RuleFor(x => x.Endereco).NotEmpty().WithMessage("O campo Endereço não pode ser nulo");
        }
    }
}
