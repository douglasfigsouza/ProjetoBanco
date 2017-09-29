using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IClienteServiceDomain
    {
        void Add(Cliente cliente);
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Update(Cliente cliente);
        void Remove(Cliente obj);
        void Dispose();
    }
}
