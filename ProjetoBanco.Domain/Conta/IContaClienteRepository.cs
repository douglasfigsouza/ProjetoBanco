using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public interface IContaClienteRepository
    {
        void PostContaCliente(Conta conta);
        ContaClienteAlteracao GetConta(int contaId);
        void PutConta(Conta conta);
        List<ContaCliente> GetAllDadosEClientesDaConta();
    }
}
