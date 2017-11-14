using ProjetoBanco.Domain.Contas;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IContaClienteAppService
    {
        HttpResponseMessage AddContaCliente(Conta conta);
        HttpResponseMessage GetConta(int contaId);
        HttpResponseMessage UpdateConta(Conta conta);
        HttpResponseMessage GetAllContas();
    }
}
