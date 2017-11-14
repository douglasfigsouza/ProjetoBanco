using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public interface IContaClienteRepository
    {
        void AddContaCliente(Conta conta);
        ContaClienteAlteracao GetConta(int contaId);
        void UpdateConta(Conta conta);
        List<ContaClienteAlteracao> GetAllContas();
        List<ContaCliente> GetAllClientesConta();
    }
}
