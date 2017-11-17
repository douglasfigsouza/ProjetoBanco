using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class OperacoesAppService : IOperacoesAppService
    {

        public HttpResponseMessage PostOperacao(Operacoes op)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("PostOperacao", op).Result;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage VerificaDadosTransacao(Transacao transacao)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("VerificaDadosTransacao", transacao).Result;
            return response;
        }

        public HttpResponseMessage VerificaDadosTransferencia(Transacao transacao)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("VerificaDadosTransferencia", transacao).Result;
            return response;
        }


        public HttpResponseMessage ConsultaSaldo(Transacao transacao)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("ConsultaSaldo", transacao).Result;
            return response;

        }
    }
}
