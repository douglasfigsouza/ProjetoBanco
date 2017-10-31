using ProjetoBanco.Application.Interfaces;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class EstadoAppService : IEstadoAppService
    {
        public HttpResponseMessage GetAllEstados()
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Estados")
                .GetAsync("GetAllEstados").Result;
            return response;
        }

    }
}
