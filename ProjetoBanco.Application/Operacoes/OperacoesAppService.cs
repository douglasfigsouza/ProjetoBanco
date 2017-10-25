using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;
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
            response = HttpClientConf.HttpClientConfig("Operacoes").PostAsJsonAsync("AddOperacao", op).Result;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage VerificaDadosTransacao(Transacao transacao)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("VerificaDadosTransacao", transacao).Result;
            return response;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
            return null; /*_OperacaoServiceDomain.VerificaDadosTransferencia(transacao);*/
        }


        public HttpResponseMessage ConsultaSaldo(Transacao transacao)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("ConsultaSaldo", transacao).Result;
            return response;

        }
    }
}
