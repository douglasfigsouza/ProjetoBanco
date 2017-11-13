using ProjetoBanco.Domain.Agencias;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IAgenciaAppService
    {
        HttpResponseMessage AddAgencia(AgenciaDto agencia);
        HttpResponseMessage GetAgenciaByNum(int agencia);
        HttpResponseMessage GetAllAgencias();
        HttpResponseMessage UpdateAgencia(AgenciaDto agencia);

    }
}
