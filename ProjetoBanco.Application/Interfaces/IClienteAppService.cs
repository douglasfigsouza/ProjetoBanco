using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IClienteAppService
    {
        void Add(Cliente cliente);
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Update(Cliente cliente);
        void Remove(Cliente obj);
        void Dispose();
    }
}
