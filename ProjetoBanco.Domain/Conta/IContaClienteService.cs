using ProjetoBanco.Domain.Contas;

namespace ProjetoBanco.Domain.Conta
{
    public interface IContaClienteService
    {
        ContaClienteAlteracao GetConta(int contaId);
    }
}
