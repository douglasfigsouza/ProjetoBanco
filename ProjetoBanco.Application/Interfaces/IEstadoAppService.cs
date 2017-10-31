using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IEstadoAppService
    {
        HttpResponseMessage GetAllEstados();
    }
}
