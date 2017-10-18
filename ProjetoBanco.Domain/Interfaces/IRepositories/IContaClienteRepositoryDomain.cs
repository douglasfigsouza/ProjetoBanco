using System.Collections.Generic;

using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IContaClienteRepositoryDomain
    {
        string AddContaCliente(Conta conta, List<ContaCliente>contaClientes);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        string UpdateConta(Conta conta);
        void Dispose();
    }
}
