using ProjetoBanco.Domain.Clientes.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Clientes
{
    public interface IClienteRepository
    {
        void AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes(int op);
        Cliente GetClienteByCpf(string cpf);
        string UpdateClientes(Cliente cliente);
        void Dispose();
    }
}
