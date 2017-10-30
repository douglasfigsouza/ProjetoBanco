using ProjetoBanco.Domain.Clientes.Dto;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IClienteAppService
    {
        HttpResponseMessage AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes(int op);
        Cliente GetClienteByCpf(string cpf);
        string UpdateCliente(Cliente cliente);
        void Dispose();
    }
}
