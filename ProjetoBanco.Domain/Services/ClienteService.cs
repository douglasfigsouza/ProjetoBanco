using System;
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

        public void AddCliente(Cliente cliente)
        {
            _repository.AddCliente(cliente);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _repository.GetAllClientes();
        }

        public Cliente GetByClienteId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveClientes(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateClientes(Cliente cliente)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
