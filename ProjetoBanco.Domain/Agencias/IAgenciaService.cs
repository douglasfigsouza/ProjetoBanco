using System.Collections.Generic;

namespace ProjetoBanco.Domain.Agencias
{
    public interface IAgenciaService
    {
        string AddAgencia(Agencia agencia);
        Agencia GetAgenciaByNum(int agencia);
        IEnumerable<Agencia> GetAllAgencias();
        string UpdateAgencia(Agencia agencia);
    }
}
