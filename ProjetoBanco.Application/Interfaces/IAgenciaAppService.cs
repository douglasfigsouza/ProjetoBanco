
using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IAgenciaAppService
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
