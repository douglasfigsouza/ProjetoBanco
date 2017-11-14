using ProjetoBanco.Domain.Contas;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Conta
{
    public interface IContaClienteService
    {
        void AddContaCliente(Contas.Conta conta);
        ContaClienteAlteracao GetConta(int contaId);
        void UpdateConta(Contas.Conta conta);
        List<ContaCliente> GetAllDadosEClientesDaConta();

    }
}
