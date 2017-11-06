using System.Collections.Generic;

namespace ProjetoBanco.Domain.Agencia
{
    public interface IAgenciaService
    {
        void AddAgencia(Agencias.Agencia agencia);
        Agencias.Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencias.Agencia> GetAllAgencias();
        void UpdateAgencia(Agencias.Agencia agencia);
    }
}
