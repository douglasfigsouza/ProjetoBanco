
using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IContaClienteServiceDomain
    {
        void AddContaCliente(Conta conta, List<ContaCliente> contaClientes);
        ContaClienteAlteracao GetContaClienteById(string conta, int agencia, string senha);
        void Dispose();
    }
}
