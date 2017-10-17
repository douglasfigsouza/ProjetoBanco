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
    public class ContaClienteServiceDomain:IContaClienteServiceDomain
    {
        private readonly IContaClienteRepositoryDomain _contaRepositoryDomain;

        public ContaClienteServiceDomain(IContaClienteRepositoryDomain contaRepositoryDomain)
        {
            _contaRepositoryDomain = contaRepositoryDomain;
        }
        public void AddContaCliente(Conta conta, List<ContaCliente> contaClientes)
        {
           _contaRepositoryDomain.AddContaCliente(conta,contaClientes);
        }

        public void Dispose()
        {
            _contaRepositoryDomain.Dispose();
        }

        public ContaClienteAlteracao GetConta(string conta, int agencia, string senha)
        {
            return _contaRepositoryDomain.GetConta(conta,agencia,senha);
        }
    }
}
