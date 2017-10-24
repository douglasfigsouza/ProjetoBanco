using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacoesAppService
    {
        HttpResponseMessage AddOperacao(Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao, int op);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        decimal ConsultaSaldo(Transacao transacao);
    }
}
