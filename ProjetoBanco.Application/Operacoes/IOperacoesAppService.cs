using System.Net.Http;
using ProjetoBanco.Domain.Operacoes;

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
