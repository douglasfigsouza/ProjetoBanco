using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Contas;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class ContaClienteAppService : IContaClienteAppService
    {
        public HttpResponseMessage AddContaCliente(Conta conta)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("ContaCliente")
                .PostAsJsonAsync("AddContaCliente", conta).Result;
            return response;
        }

        public HttpResponseMessage GetConta(int contaId)
        {
            HttpResponseMessage response;
            //Create a query
            HttpClient client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("ContaCliente/GetConta", new
            {
                contaId

            })).Result;
            return response;
        }

        public HttpResponseMessage UpdateConta(Conta conta)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("ContaCliente")
                .PostAsJsonAsync("UpdateConta", conta).Result;
            return response;
        }
        public HttpResponseMessage GetAllDadosEClientesDaConta()
        {

            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("ContaCliente")
                .GetAsync("GetAllDadosEClientesDaConta").Result;
            return response;
        }
    }
}
