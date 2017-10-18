using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IAgenciaRepositoryDomain
    {
        void AddAgencia(Agencia agencia);
        Agencia GetByAgenciaId(int id);
        Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencia> GetAllAgencias();
        void UpdateAgencia(Agencia agencia);
        void RemoveAgencia(Agencia agencia);
        void Dispose();
    }
}
