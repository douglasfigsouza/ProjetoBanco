using System.Collections.Generic;

namespace ProjetoBanco.Domain.Agencias
{
    public interface IAgenciaRepository
    {
        void AddAgencia(AgenciaDto agencia);
        AgenciaDto GetAgenciaByNum(int agencia);
        IEnumerable<AgenciaDto> GetAllAgencias();
        void UpdateAgencia(AgenciaDto agencia);
    }
}
