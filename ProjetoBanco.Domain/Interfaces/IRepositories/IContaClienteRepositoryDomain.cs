using System.Collections.Generic;

using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IContaClienteRepositoryDomain
    {
        void AddContaCliente(Conta conta, List<ContaCliente>contaClientes);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        void UpdateConta(Conta conta);
        void Dispose();
    }
}
