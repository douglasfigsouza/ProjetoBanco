
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Clientes.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteServiceDomain _iClienteService;
        private readonly IClienteRepository _clienteRepositoryDomain;
        public ClienteAppService(IClienteServiceDomain iClienteService, IClienteRepository clienteRepositoryDomain)
        {
            _iClienteService = iClienteService;
            _clienteRepositoryDomain = clienteRepositoryDomain;
        }


        public HttpResponseMessage AddCliente(Cliente cliente)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Clientes")
                .PostAsJsonAsync("AddOCliente", cliente).Result;
            return response;
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

        public string UpdateCliente(Cliente cliente)
        {
           return _clienteRepositoryDomain.UpdateClientes(cliente);
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
