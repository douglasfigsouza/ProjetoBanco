using System.Collections.Generic;

namespace ProjetoBanco.Domain.Clientes
{
    public interface IClienteRepository
    {
        void AddCliente(ClienteDto cliente);
        ClienteDto GetByClienteId(int id);
        IEnumerable<ClienteDto> GetAllClientes(int op);
        ClienteDto GetClienteByCpf(string cpf);
        void UpdateClientes(ClienteDto cliente);
    }
}
