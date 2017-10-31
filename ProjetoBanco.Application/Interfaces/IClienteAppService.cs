using ProjetoBanco.Domain.Clientes.Dto;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IClienteAppService
    {
        HttpResponseMessage AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        HttpResponseMessage GetAllClientes(int op);
        Cliente GetClienteByCpf(string cpf);
        HttpResponseMessage UpdateCliente(Cliente cliente);
        void Dispose();
    }
}
