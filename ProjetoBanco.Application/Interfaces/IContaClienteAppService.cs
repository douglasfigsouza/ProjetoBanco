using ProjetoBanco.Domain.Contas;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IContaClienteAppService
    {
        HttpResponseMessage PostContaCliente(Conta conta);
        HttpResponseMessage GetConta(int contaId);
        HttpResponseMessage PutConta(Conta conta);
        HttpResponseMessage GetAllDadosEClientesDaConta();
    }
}
