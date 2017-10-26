using System;
using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class ContaClienteAppService:IContaClienteAppService
    {
        private readonly IContaClienteServiceDomain _contaClienteServiceDomain;
        private readonly IContaClienteRepositoryDomain _contaClienteRepositoryDomain;

        public ContaClienteAppService(IContaClienteServiceDomain contaClienteServiceDomain, IContaClienteRepositoryDomain contaClienteRepositoryDomain)
        {
            _contaClienteServiceDomain = contaClienteServiceDomain;
            _contaClienteRepositoryDomain = contaClienteRepositoryDomain;
        }
        public string AddContaCliente(Conta conta, List<ContaCliente> contaClientes)
        {
          return _contaClienteRepositoryDomain.AddContaCliente(conta,contaClientes);
        }

        public ContaClienteAlteracao GetConta(string conta, int agencia, string senha)
        {
            return _contaClienteRepositoryDomain.GetConta(conta,  agencia, senha);
        }

        public string UpdateConta(Conta conta)
        {
           return _contaClienteRepositoryDomain.UpdateConta(conta);
        }

        public void Dispose()
        {
           _contaClienteRepositoryDomain.Dispose();
           _contaClienteServiceDomain.Dispose();
        }
    }
}
