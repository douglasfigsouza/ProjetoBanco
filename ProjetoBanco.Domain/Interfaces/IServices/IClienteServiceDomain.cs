using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IClienteServiceDomain
    {
        void AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes(int op);
        void UpdateClientes(Cliente cliente);
        void RemoveClientes(Cliente obj);
        void Dispose();
    }
}
