using System.Net.Http;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Operacoes;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class OperacoesAppService : IOperacoesAppService
    {
        public HttpResponseMessage AddOperacao(Operacoes op)
        {
            HttpResponseMessage response = HttpClientConf.HttpClientConfig("Operacoes").PostAsJsonAsync("AddOperacao", op).Result;
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
