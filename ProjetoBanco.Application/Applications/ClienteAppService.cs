using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Clientes;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class ClienteAppService : IClienteAppService
    {
        public HttpResponseMessage AddCliente(ClienteDto cliente)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Clientes")
                .PostAsJsonAsync("AddCliente", cliente).Result;
            return response;
        }

        public HttpResponseMessage GetByClienteId(int id)
        {
            HttpResponseMessage response;
            //Create a query
            HttpClient client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Clientes/GetByClienteId", new
            {
                id
            })).Result;
            return response;
        }

        public HttpResponseMessage GetAllClientes(int op)
        {
            HttpResponseMessage response;
            //Create a query
            HttpClient client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Clientes/GetAllClientes", new
            {
                op
            })).Result;
            return response;
        }

        public HttpResponseMessage GetClienteByCpf(string cpf)
        {
            HttpResponseMessage response;
            //Create a query
            HttpClient client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Clientes/GetByClienteId", new
            {
                cpf
            })).Result;
            return response;
        }

        public HttpResponseMessage UpdateCliente(ClienteDto cliente)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Clientes")
                .PostAsJsonAsync("UpdateCliente", cliente).Result;
            return response;
        }

    }
}
