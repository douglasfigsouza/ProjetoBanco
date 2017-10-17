﻿using System;
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
        public void AddContaCliente(Conta conta, List<ContaCliente> contaClientes)
        {
           _contaClienteRepositoryDomain.AddContaCliente(conta,contaClientes);
        }

        public ContaClienteAlteracao GetContaCliente(string conta, int agencia, string senha)
        {
            return _contaClienteRepositoryDomain.GetContaCliente(conta,  agencia, senha);
        }

        public void Dispose()
        {
           _contaClienteRepositoryDomain.Dispose();
           _contaClienteServiceDomain.Dispose();
        }
    }
}
