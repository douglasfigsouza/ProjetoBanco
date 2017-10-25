using System.Net.Http;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacoesAppService
    {
        HttpResponseMessage AddOperacao(Operacoes op);
        HttpResponseMessage VerificaDadosTransacao(Transacao transacao);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        HttpResponseMessage ConsultaSaldo(Transacao transacao);
    }
}
