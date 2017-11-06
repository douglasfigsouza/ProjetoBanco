using ProjetoBanco.Domain.Contas;

namespace ProjetoBanco.Domain.Conta
{
    public interface IContaClienteService
    {
        void AddContaCliente(Contas.Conta conta);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        void UpdateConta(Contas.Conta conta);
    }
}
