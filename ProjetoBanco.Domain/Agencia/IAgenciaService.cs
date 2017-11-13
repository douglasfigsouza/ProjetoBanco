using System.Collections.Generic;

namespace ProjetoBanco.Domain.Agencia
{
    public interface IAgenciaService
    {
        void AddAgencia(Agencias.AgenciaDto agencia);
        Agencias.AgenciaDto GetAgenciaByNum(int agencia);
        IEnumerable<Agencias.AgenciaDto> GetAllAgencias();
        void UpdateAgencia(Agencias.AgenciaDto agencia);
    }
}
