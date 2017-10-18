
using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IContaClienteServiceDomain
    {
        string AddContaCliente(Conta conta, List<ContaCliente> contaClientes);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        string UpdateConta(Conta conta);
        void Dispose();
    }
}
