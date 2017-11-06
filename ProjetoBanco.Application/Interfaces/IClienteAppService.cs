using ProjetoBanco.Domain.Clientes;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IClienteAppService
    {
        HttpResponseMessage AddCliente(Cliente cliente);
        HttpResponseMessage GetByClienteId(int id);
        HttpResponseMessage GetAllClientes(int op);
        HttpResponseMessage GetClienteByCpf(string cpf);
        HttpResponseMessage UpdateCliente(Cliente cliente);
    }
}
