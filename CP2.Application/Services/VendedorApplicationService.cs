using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            return _repository.DeletarDados(id);
        }

        public VendedorEntity? EditarDados(int id, IVendedorDto entity)
        {
            entity.Validate();
            return _repository.EditarDados(new VendedorEntity
            {
                Id = id,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                ComissaoPercentual = entity.ComissaoPercentual,
                MetaMensal = entity.MetaMensal,
            });
        }

        public VendedorEntity? ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? SalvarDados(IVendedorDto entity)
        {
            entity.Validate();
            return _repository.SalvarDados(new VendedorEntity
            {
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                DataNascimento = entity.DataNascimento,
                DataContratacao = entity.DataContratacao,
                ComissaoPercentual = entity.ComissaoPercentual,
                MetaMensal = entity.MetaMensal
            });
        }
    }
}
