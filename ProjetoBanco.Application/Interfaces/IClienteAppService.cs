using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IClienteAppService
    {
        string AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes(int op);
        Cliente GetClienteByCpf(string cpf);
        void UpdateCliente(Cliente cliente);
        void RemoveCliente(Cliente cliente);
        void Dispose();
    }
}
