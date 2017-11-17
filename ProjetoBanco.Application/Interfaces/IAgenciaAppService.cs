using ProjetoBanco.Domain.Agencias;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IAgenciaAppService
    {
        HttpResponseMessage PostAgencia(AgenciaDto agencia);
        HttpResponseMessage GetAgenciaByNum(int agencia);
        HttpResponseMessage GetAllAgencias();
        HttpResponseMessage PutAgencia(AgenciaDto agencia);

    }
}
