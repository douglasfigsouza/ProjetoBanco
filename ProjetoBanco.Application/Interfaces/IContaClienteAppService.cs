using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IContaClienteAppService
    {
        void AddContaCliente(Conta conta, List<ContaCliente> contaCliente);
        ContaClienteAlteracao GetContaCliente(string conta, int agencia, string senha);
        void Dispose();
    }
}
