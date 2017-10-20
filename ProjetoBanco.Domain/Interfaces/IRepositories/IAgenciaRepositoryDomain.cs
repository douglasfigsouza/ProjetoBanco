using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IAgenciaRepositoryDomain
    {
        string AddAgencia(Agencia agencia);
        Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencia> GetAllAgencias();
        string UpdateAgencia(Agencia agencia);
        void Dispose();
    }
}
