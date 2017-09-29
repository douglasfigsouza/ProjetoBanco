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

        public void Add(Cliente cliente)
        {
            _repository.Add(cliente);
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
