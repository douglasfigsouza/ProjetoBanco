using ProjetoBanco.Application.Interfaces;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class CidadeAppService : ICidadesAppService
    {
        public HttpResponseMessage GetCidadesByEstadoId(int id)
        {
            var response = new HttpResponseMessage();
            var client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Cidades/GetCidadesByEstadoId", new
            {
                id
            })).Result;
            return response;
        }

    }
}
