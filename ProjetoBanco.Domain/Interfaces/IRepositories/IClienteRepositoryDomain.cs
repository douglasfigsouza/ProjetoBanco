using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IClienteRepositoryDomain
    {
        string AddCliente(Cliente cliente);
        Cliente GetByClienteId(int id);
        IEnumerable<Cliente> GetAllClientes(int op);
        Cliente GetClienteByCpf(string cpf);
        string UpdateClientes(Cliente cliente);
        void Dispose();
    }
}
