using System.Collections.Generic;

namespace ProjetoBanco.Domain.Agencias
{
    public interface IAgenciaRepository
    {
        void AddAgencia(Agencia agencia);
        Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencia> GetAllAgencias();
        void UpdateAgencia(Agencia agencia);
    }
}
