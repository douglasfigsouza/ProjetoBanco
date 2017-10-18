using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IAgenciaServiceDomain
    {
        string AddAgencia(Agencia agencia);
        Agencia GetByAgenciaId(int id);
        Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencia> GetAllAgencias();
        string UpdateAgencia(Agencia agencia);
        void Dispose();
    }
}
