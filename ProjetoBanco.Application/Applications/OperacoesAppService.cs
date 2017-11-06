using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Net.Http;
using System.Web.Http;
using ProjetoBanco.Domain.Operacoes;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class OperacoesAppService : IOperacoesAppService
    {

        public HttpResponseMessage AddOperacao(Operacoes op)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("AddOperacao", op).Result;
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
