using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IAgenciaAppService
    {
        string AddAgencia(Agencia agencia);
        Agencia GetByAgenciaId(int id);
        Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencia> GetAllAgencias();
        string UpdateAgencia(Agencia agencia);
        void Dispose();
    }
}
