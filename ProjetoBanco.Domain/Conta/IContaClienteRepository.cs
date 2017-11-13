using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public interface IContaClienteRepository
    {
        void AddContaCliente(Conta conta);
        ContaClienteAlteracao GetConta(string conta, string senha);
        void UpdateConta(Conta conta);
        List<ContaClienteAlteracao> GetAllContas();
    }
}
