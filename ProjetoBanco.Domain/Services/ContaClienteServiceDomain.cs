using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class ContaClienteServiceDomain : IContaClienteServiceDomain
    {
        private readonly IContaClienteRepositoryDomain _contaRepositoryDomain;

        public ContaClienteServiceDomain(IContaClienteRepositoryDomain contaRepositoryDomain)
        {
            _contaRepositoryDomain = contaRepositoryDomain;
        }
        public string AddContaCliente(Conta conta, List<ContaCliente> contaClientes)
        {
            return _contaRepositoryDomain.AddContaCliente(conta, contaClientes);
        }

        public string UpdateConta(Conta conta)
        {
            return _contaRepositoryDomain.UpdateConta(conta);
        }

        public void Dispose()
        {
            _contaRepositoryDomain.Dispose();
        }

        public ContaClienteAlteracao GetConta(string conta, int agencia, string senha)
        {
            return _contaRepositoryDomain.GetConta(conta, agencia, senha);
        }
    }
}
