using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var url= new  Uri("api/Operacoes/AddOperacao");
            var result = HttpClient.GetAsync(url).GetAwaiter().GetResult();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.Timeout = new TimeSpan(60000000000);
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (result.StatusCode != HttpStatusCode.OK)
            {

                return null;
            }
            return JsonConvert.DeserializeObject<Operacoes>(resultContent);
        }

        public Transacao VerificaDadosTransacao(Transacao transacao, int op)
        {
            return/* _OperacaoServiceDomain.VerificaDadosTransacao(transacao,op)*/;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
           return _OperacaoServiceDomain.VerificaDadosTransferencia(transacao);
        }


        public decimal ConsultaSaldo(Transacao transacao)
        {
            decimal saldo= _OperacaoRepositoryDomain.ConsultaSaldo(transacao);
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
