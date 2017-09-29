
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

        public void Add(Cliente cliente)
        {
            _iClienteService.Add(cliente);
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
            throw new NotImplementedException();
        }
    }
}
