
using System;
using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteServiceDomain _iClienteService;
        private readonly IClienteRepositoryDomain _clienteRepositoryDomain;
        public ClienteAppService(IClienteServiceDomain iClienteService, IClienteRepositoryDomain clienteRepositoryDomain)
        {
            _iClienteService = iClienteService;
            _clienteRepositoryDomain = clienteRepositoryDomain;
        }

        public string AddCliente(Cliente cliente)
        {
            return _iClienteService.AddCliente(cliente);
        }

        public Cliente GetByClienteId(int id)
        {
            return _clienteRepositoryDomain.GetByClienteId(id);
        }

        public IEnumerable<Cliente> GetAllClientes(int op)
        {
            return _iClienteService.GetAllClientes(op);
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            return _clienteRepositoryDomain.GetClienteByCpf(cpf);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepositoryDomain.UpdateClientes(cliente);
        }

        public void RemoveCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _clienteRepositoryDomain.Dispose();
        }
    }
}
