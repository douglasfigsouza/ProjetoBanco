using ProjetoBanco.Domain.Clientes.Dto;
using System;
using System.Collections.Generic;


namespace ProjetoBanco.Domain.Clientes
{
    public class ClienteService : IClienteServiceDomain
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void AddCliente(Cliente cliente)
        {
           _repository.AddCliente(cliente);
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

        public void UpdateClientes(Cliente cliente)
        {
           _repository.UpdateClientes(cliente);
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
