using System.Collections.Generic;

namespace ProjetoBanco.Domain.Agencias
{
    public interface IAgenciaRepository
    {
        void PostAgencia(AgenciaDto agencia);
        AgenciaDto GetAgenciaByNum(int agencia);
        IEnumerable<AgenciaDto> GetAllAgencias();
        void PutAgencia(AgenciaDto agencia);
    }
}
