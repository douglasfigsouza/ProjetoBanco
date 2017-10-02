using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IClienteAppService
    {
        void AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes();
        void UpdateCliente(Cliente cliente);
        void RemoveCliente(Cliente cliente);
        void Dispose();
    }
}
