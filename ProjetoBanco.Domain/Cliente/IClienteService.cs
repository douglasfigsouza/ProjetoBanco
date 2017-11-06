using System.Collections.Generic;

namespace ProjetoBanco.Domain.Clientes
{
    public interface IClienteService
    {
        void AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes(int op);
        Cliente GetClienteByCpf(string cpf);
        void UpdateClientes(Cliente cliente);
    }
}
