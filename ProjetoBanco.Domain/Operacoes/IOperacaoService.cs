using System.Net.Http;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IOperacaoService
    {
        HttpResponseMessage AddOperacao(Operacoes.Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao, int op);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        decimal ConsultaSaldo(Transacao transacao);
    }
}
