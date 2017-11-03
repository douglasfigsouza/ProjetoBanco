namespace ProjetoBanco.Domain.Contas
{
    public interface IContaClienteRepository
    {
        void AddContaCliente(Conta conta);
        ContaClienteAlteracao GetConta(string conta, int agencia, string senha);
        void UpdateConta(Conta conta);
    }
}
