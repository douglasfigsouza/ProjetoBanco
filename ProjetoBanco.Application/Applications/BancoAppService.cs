using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Bancos;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class BancoAppService : IBancoAppService
    {
        public HttpResponseMessage AddBanco(Banco banco)
        {
            var response = new HttpResponseMessage();
            response = HttpClientConf.HttpClientConfig("Banco")
                .PostAsJsonAsync("AddBanco", banco).Result;
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
