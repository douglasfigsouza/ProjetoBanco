
using System;
using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteServiceDomain _iClienteService;
        public ClienteAppService(IClienteServiceDomain iClienteService)
        {
            _iClienteService = iClienteService;
        }

        public void AddCliente(Cliente cliente)
        {
            _iClienteService.AddCliente(cliente);
        }

        public Cliente GetByClienteId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
