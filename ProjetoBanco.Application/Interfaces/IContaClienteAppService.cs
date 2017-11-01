using ProjetoBanco.Domain.Contas;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IContaClienteAppService
    {
        HttpResponseMessage AddContaCliente(Conta conta);
        HttpResponseMessage GetConta(string conta, int agencia, string senha);
        HttpResponseMessage UpdateConta(Conta conta);
    }
}
