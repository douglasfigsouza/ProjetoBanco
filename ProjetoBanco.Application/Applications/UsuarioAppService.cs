using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Usuarios;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {

        public HttpResponseMessage PostUsuario(UsuarioDto usuario)
        {
            var response = HttpClientConf.HttpClientConfig("Usuarios")
                 .PostAsJsonAsync("PostUsuario", usuario).Result;
            return response;
        }

        public HttpResponseMessage GetByUsuarioId(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Usuarios/GetByUsuarioId", new
            {
                id
            })).Result;
            return response;
        }

        public HttpResponseMessage GetAllUsuarios()
        {
            var response = HttpClientConf.HttpClientConfig("Usuarios")
                .GetAsync("GetAllUsuarios").Result;
            return response;
        }

        public HttpResponseMessage PutUsuario(UsuarioDto usuario)
        {
            var response = HttpClientConf.HttpClientConfig("Usuarios")
                .PutAsJsonAsync("PutUsuario", usuario).Result;
            return response;
        }

        public HttpResponseMessage VerificaLogin(UsuarioDto usuario)
        {
            var response = HttpClientConf.HttpClientConfig("Usuarios")
                .PostAsJsonAsync("VerificaLogin", usuario).Result;
            return response;
        }
    }
}
