﻿using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            return _repository.DeletarDados(id);
        }

        public FornecedorEntity? EditarDados(int id, IFornecedorDto entity)
        {
            entity.Validate();
            return _repository.EditarDados(new FornecedorEntity
            {
                Id = id,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone,
                Endereco = entity.Endereco,
            });
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? SalvarDados(IFornecedorDto entity)
        {
            entity.Validate();
            return _repository.SalvarDados(new FornecedorEntity
            {
                Nome = entity.Nome,
                Email = entity.Email,
                CNPJ = entity.CNPJ,
                Telefone = entity.Telefone,
                Endereco = entity.Endereco
            });
        }
    }
}
