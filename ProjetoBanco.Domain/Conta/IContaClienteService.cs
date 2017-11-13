using ProjetoBanco.Domain.Contas;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Conta
{
    public interface IContaClienteService
    {
        void AddContaCliente(Contas.Conta conta);
        ContaClienteAlteracao GetConta(string conta, string senha);
        void UpdateConta(Contas.Conta conta);
        List<ContaClienteAlteracao> GetAllContas();

    }
}
