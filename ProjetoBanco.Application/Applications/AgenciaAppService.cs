using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Agencias;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class AgenciaAppService : IAgenciaAppService
    {

        public HttpResponseMessage AddAgencia(Agencia agencia)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Agencias")
                .PostAsJsonAsync("AddAgencia", agencia).Result;
            return response;
        }

        public HttpResponseMessage GetAllAgencias()
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Agencias")
                .GetAsync("GetAllAgencias").Result;
            return response;
        }

        public HttpResponseMessage UpdateAgencia(Agencia agencia)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Agencias")
                .PostAsJsonAsync("UpdateAgencia", agencia).Result;
            return response;
        }

        public HttpResponseMessage GetAgenciaByNum(int agencia)
        {
            HttpResponseMessage response;
            //Create a query
            HttpClient client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Agencias/GetAgenciaByNum", new
            {
                agencia
            })).Result;
            return response;
        }
    }
}
