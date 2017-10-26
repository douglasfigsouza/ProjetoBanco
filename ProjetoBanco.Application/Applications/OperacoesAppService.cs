using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class OperacoesAppService : IOperacoesAppService
    {
        private HttpResponseMessage response;
        private readonly Notifications _notifications;

        public OperacoesAppService(Notifications notifications)
        {
            _notifications = notifications;
        }

        public HttpResponseMessage AddOperacao(Operacoes op)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("AddOperacao", op).Result;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage VerificaDadosTransacao(Transacao transacao)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("VerificaDadosTransacao", transacao).Result;
            return response;
        }

        public HttpResponseMessage VerificaDadosTransferencia(Transacao transacao)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("VerificaDadosTransferencia", transacao).Result;
            return response;
        }


        public HttpResponseMessage ConsultaSaldo(Transacao transacao)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("ConsultaSaldo", transacao).Result;
            return response;

        }
    }
}
