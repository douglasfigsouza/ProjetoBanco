using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IContaClienteAppService
    {
        string AddContaCliente(Conta conta, List<ContaCliente> contaCliente);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        string UpdateConta(Conta conta);
        void Dispose();
    }
}
