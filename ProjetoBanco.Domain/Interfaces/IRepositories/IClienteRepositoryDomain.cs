using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IClienteRepositoryDomain
    {
        void Add(Cliente cliente);
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Update(Cliente cliente);
        void Remove(Cliente obj);
        void Dispose();
    }
}
