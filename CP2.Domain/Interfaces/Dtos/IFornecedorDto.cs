namespace CP2.Domain.Interfaces.Dtos
{
    public interface IFornecedorDto
    {
        string Nome { get; set; }
        string CNPJ { get; set; }
        string Email { get; set; }
        string Telefone { get; set; }
        string Endereco { get; set; }

        void Validate();
    }
}
