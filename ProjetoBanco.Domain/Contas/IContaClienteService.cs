using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public interface IContaClienteService
    {
        string AddContaCliente(Conta conta, List<ContaCliente> contaClientes);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        string UpdateConta(Conta conta);
        void Dispose();
    }
}
