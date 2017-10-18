﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class ClienteService : IClienteServiceDomain
    {
        private readonly IClienteRepositoryDomain _repository;

        public ClienteService(IClienteRepositoryDomain repository)
        {
            _repository = repository;
        }

        public string AddCliente(Cliente cliente)
        {
           return _repository.AddCliente(cliente);
        }

        public IEnumerable<Cliente> GetAllClientes(int op)
        {
            return _repository.GetAllClientes(op);
        }

        public Cliente GetByClienteId(int id)
        {
            return _repository.GetByClienteId(id);
        }

        public void RemoveClientes(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public string UpdateClientes(Cliente cliente)
        {
            return _repository.UpdateClientes(cliente);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            return _repository.GetClienteByCpf(cpf);
        }
    }
}
