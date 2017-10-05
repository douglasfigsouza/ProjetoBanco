using System.Collections.Generic;

using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IContaClienteRepositoryDomain
    {
        void AddContaCliente(Conta conta, List<ContaCliente>contaClientes);
        void Dispose();
    }
}
