using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application
{
    public class OperacoesAppService : IOperacoesAppService
    {
   
        public HttpResponseMessage AddOperacao(Operacoes op)
        {
            var HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("api/Operacoes/AddOperacao");
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       
            HttpResponseMessage response = HttpClient.PostAsJsonAsync("operacao", op).Result;

            return response;

        }

        public Transacao VerificaDadosTransacao(Transacao transacao, int op)
        {
            return null/* _OperacaoServiceDomain.VerificaDadosTransacao(transacao,op)*/;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
            return null; /*_OperacaoServiceDomain.VerificaDadosTransferencia(transacao);*/
        }


        public decimal ConsultaSaldo(Transacao transacao)
        {
            decimal saldo = 0; /*_OperacaoRepositoryDomain.ConsultaSaldo(transacao);*/
            if( saldo==(-1))
            {
                return -1;
            }
            else
            {
                return saldo;
            }
        }

    }
}
