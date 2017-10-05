
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

        public void AddCliente(Cliente cliente)
        {
            _iClienteService.AddCliente(cliente);
        }

        public Cliente GetByClienteId(int id)
        {
            return _clienteRepositoryDomain.GetByClienteId(id);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _iClienteService.GetAllClientes();
        }

        public void UpdateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
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
