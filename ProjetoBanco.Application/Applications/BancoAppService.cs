using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Bancos;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class BancoAppService : IBancoAppService
    {
        public HttpResponseMessage PostBanco(Banco banco)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Banco")
                .PostAsJsonAsync("PostBanco", banco).Result;
            return response;
        }

        public HttpResponseMessage GetAllBancos()
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Banco")
                .GetAsync("GetAllBancos").Result;
            return response;
        }
    }
}
